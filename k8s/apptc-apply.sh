#!/bin/bash

# Apply secret
kubectl apply -f apptc-secret.yaml

# Apply deployment
kubectl apply -f apptc-deployment.yaml

# Apply service
kubectl apply -f apptc-svc.yaml

# Apply hpa
kubectl apply -f apptc-hpa.yaml

echo "Configurações aplicadas!"
