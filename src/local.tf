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
    name = "identity-api"
  }
}

resource "kubernetes_deployment" "identity" {
  metadata {
    name = "identity-api"
    namespace = kubernetes_namespace.identity.metadata.0.name
    labels = {
      app = "IdentityApi"
    }
  }

  spec {
    replicas = 2
    selector {
      match_labels = {
        app = "identity-api"
      }
    }
    template {
      metadata {
        labels = {
          app = "identity-api"
        }
      }
      spec {
        container {
          image = "identity-api:latest"
          name = "identity-api-container"
          image_pull_policy = "IfNotPresent"
          port {
            container_port = 80
            protocol = "TCP"
          }
          env {
            name = "ASPNETCORE_URLS"
            value = "http://+:80"
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "identity" {
  metadata {
    name = "identity-api"
    namespace = kubernetes_namespace.identity.metadata.0.name
    labels = {
      app = "identity-api"
    }
  }
  spec {
    type = "LoadBalancer"
    port {
      port = "5000"
      target_port = "80"
      protocol = "TCP"
    }
    selector = {
      app = kubernetes_deployment.identity.spec.0.template.0.metadata.0.labels.app
    }
  }
}