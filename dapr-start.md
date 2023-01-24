```
dapr run --app-id myapp --dapr-http-port 3500
```

## Service Invocation

```
dapr run --app-port 7001 --app-id order-processor --app-protocol http --dapr-http-port 3501 -- dotnet run
```

```
dapr run --app-id checkout --app-protocol http --dapr-http-port 3500 -- dotnet run
```

### Resilliency

```
dapr run  --app-id checkout --config ../config.yaml --components-path ../../../components/ --app-protocol http --dapr-http-port 3500 -- dotnet run
```

## Pub sub

```
dapr run --app-id order-processor --components-path ../../../components --app-port 7002 -- dotnet run
```

```
dapr run --app-id checkout --components-path ../../../components -- dotnet run

```

kubectl run --namespace default my-redis-redis-cluster-client `
  --rm --tty -i --restart='Never' `
  --env REDIS_PASSWORD=$Env:REDIS_PASSWORD `
  --image docker.io/bitnami/redis-cluster:6.2.6-debian-10-r137 -- bash

az k8s-extension create --cluster-type managedClusters `
    --cluster-name avkdapr `
    --resource-group dapr `
    --name dapr `
    --extension-type Microsoft.Dapr `
    --auto-upgrade-minor-version true

kubectl create secret generic redis --from-literal=redis-password=T0NQMmhSTXhSTA==
