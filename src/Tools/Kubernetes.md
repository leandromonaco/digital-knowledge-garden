`winget install Kubernetes.kubectl` 

- Clusters -> Nodes -> PODs -> 1 or more containers
- Controllers (Job / CronJob)
- Worker
- Ingress Controller (Nginx)

## Update Kube File
`aws eks update-kubeconfig --name au-sandbox --region ap-southeast-2`

## Kubernetes API
`kubectl api-resources`

## Namespaces
`kubectl create namespace leandrom`
`kubectl delete namespace leandrom`
`kubectl get namespaces`

## POD
https://kubernetes.io/docs/concepts/workloads/pods/
`kubectl apply -n leandrom -f hello-world.yml`
`kubectl apply -f hello-world.yml`
`kubectl get pods -n leandrom`
`kubectl describe pod hello-world -n leandrom`
`kubectl logs hello-world -n leandrom`
`kubectl delete pod hello-world -n leandrom`

`hello-world.yml`
```
apiVersion: v1
kind: Pod
metadata:
  name: hello-world
  namespace: leandrom
spec:
  restartPolicy: Always
  containers:
    - name: main
      image: busybox
      command: ['sh', '-c', 'echo $MESSAGE && sleep 10 && echo Bye!']
      env:
        - name: MESSAGE
          value: "Hello env vars!"
```
### Restart Policy
https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle/#restart-policy

The `spec` of a Pod has a `restartPolicy` field with possible values `Always`, `OnFailure`, and `Never`. The default value is Always.

## Controllers
### Jobs
`kubectl get job -n leandrom`
`kubectl delete job hellojob -n leandrom`

```
apiVersion: batch/v1
kind: Job
metadata:
  name: hellojob
  namespace: leandrom
spec:
  completions: 20
  parallelism: 2
  template:
    metadata:
      name: hello-job
    spec:
      containers:
        - name: main
          image: busybox
          command: ['sh', '-c', 'echo $MESSAGE && sleep 10 && echo Bye!']
          env:
            - name: MESSAGE
              value: "Hello env vars!"
      restartPolicy: OnFailure
```

### Cron Jobs

```
apiVersion: batch/v1
kind: CronJob
metadata:
  name: hellocron
  namespace: leandrom
spec:
  schedule: "* * * * *"
  jobTemplate:
    spec:
      template:
        spec:
          containers:
          - name: main
            image: busybox
            command: ['sh', '-c', 'echo $MESSAGE && sleep 10 && echo Bye!']
            env:
              - name: MESSAGE
                value: "Hello env vars!"
          restartPolicy: OnFailure
```
## Export/Import Resources
`kubectl get namespace leandrom -o yaml`
`kubectl get pod debian -n leandrom -o yaml`
`kubectl apply -f namespace.yaml`
`kubectl apply -f pod.yaml` 


## References

[Kubernetes 101: Pods, Nodes, Containers, and Clusters](https://medium.com/google-cloud/kubernetes-101-pods-nodes-containers-and-clusters-c1509e409e16)