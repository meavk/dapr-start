docker build . -f .\order-processor\Dockerfile -t orderprocessor
docker build . -f .\order-checkout\Dockerfile -t ordercheckout

docker tag orderprocessor avkcontainerregistry.azurecr.io/orderprocessor:v5
docker tag orderprocessor avkcontainerregistry.azurecr.io/ordercheckout:v5

az acr login -n avkcontainerregistry

docker push avkcontainerregistry.azurecr.io/orderprocessor:v5
docker push avkcontainerregistry.azurecr.io/ordercheckout:v5