#!/bin/bash

# Delete secret
kubectl delete -f apptc-secret.yaml

# Delete deployment
kubectl delete -f apptc-deployment.yaml

# Delete service
kubectl delete -f apptc-svc.yaml

# Delete hpa
kubectl delete -f apptc-hpa.yaml

echo "Configurações deletadas!"
