variable "src_name" {
  description = "Source name"
  type        = string
  default     = "identity-api"
}

variable "deployment_label" {
  description = "Deployment Label / Container Name"
  type        = string
  default     = "IdentityApi"
}

variable "secret_name" {
  description = "Secret name"
  type        = string
  default     = "identity-secrets"
}

variable "service_port" {
  description = "Internal service port"
  type        = number
  default     = 5100
}

variable "subdomain" {
  description = "Host subdomain to expose on Ingress"
  type        = string
  default     = "identity"
}

variable "environment-prefix" {
  description = "Host environment to expose on Ingress"
  type        = string
  default     = "rc-"
}

variable "host" {
  description = "Host suffix to expose on Ingress"
  type        = string
  default     = "albedo.team"
}

variable "broker_connection_string" {
  description = "Broker Connection String"
  type        = string
  sensitive   = true
  default     = ""
}

variable "replicas_count" {
  description = "Number of container replicas to provision."
  type        = number
  default     = 1
}