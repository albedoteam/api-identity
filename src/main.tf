terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = ">= 2.0.0"
    }
  }
}

provider "kubernetes" {
  config_path = "~/.kube/config"
}

resource "kubernetes_namespace" "identity" {
  metadata {
    name = var.src_name
  }
}

resource "kubernetes_secret" "identity" {
  metadata {
    name      = var.secret_name
    namespace = kubernetes_namespace.identity.metadata.0.name
  }
  data = {
    Broker_Host = var.broker_connection_string
  }
}

resource "kubernetes_deployment" "identity" {
  metadata {
    name      = var.src_name
    namespace = kubernetes_namespace.identity.metadata.0.name
    labels = {
      app = var.deployment_label
    }
  }

  spec {
    replicas = var.replicas_count
    selector {
      match_labels = {
        app = var.src_name
      }
    }
    template {
      metadata {
        labels = {
          app = var.src_name
        }
      }
      spec {
        container {
          image             = "${var.src_name}:latest"
          name              = "${var.src_name}-container"
          image_pull_policy = "IfNotPresent"
          resources {
            limits = {
              cpu    = "0.5"
              memory = "512Mi"
            }
            requests = {
              cpu    = "250m"
              memory = "50Mi"
            }
          }
          port {
            container_port = 80
            protocol       = "TCP"
          }
          env {
            name  = "ASPNETCORE_URLS"
            value = "http://+:80"
          }
          env_from {
            secret_ref {
              name = var.secret_name
            }
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "identity" {
  metadata {
    name      = var.src_name
    namespace = kubernetes_namespace.identity.metadata.0.name
    labels = {
      app = var.src_name
    }
  }
  spec {
    type = "LoadBalancer"
    port {
      port        = "5100"
      target_port = "80"
      protocol    = "TCP"
    }
    selector = {
      app = kubernetes_deployment.identity.spec.0.template.0.metadata.0.labels.app
    }
  }
}