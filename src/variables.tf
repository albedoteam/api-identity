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