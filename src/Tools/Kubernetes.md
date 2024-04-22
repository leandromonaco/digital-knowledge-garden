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

## POD Controllers

Kubernetes provides 4 types of long running pod controllers:

- Deployments - Make sure n pods of the same type are running at any time. More ephemeral. They can share volumes. Best for stateless applications like APIs, microservices, webservers.
- Statefulsets - Same as deployments but the network name of the pods are consistent and usually don’t share volumes (but might for coordination). Best for stateful applications like databases.
- Daemonsets - Make sure one pod runs on every host.
- Replicaset - Light implementation of pod replication that tries to keep a number of pods active at the same time, used by Deployments with improved features. **Do not use directly.**

## Deployment

`httpd.yml`

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: httpd
  namespace: leandrom
  labels:
    app: httpd_app
spec:
  replicas: 4
  selector:
      matchLabels:
        mypod: httpd_pod
  template:
    metadata:
      labels:
        mypod: httpd_pod
    spec:
      containers:
        - name: main
          image: httpd:latest
          ports:
            - containerPort: 80
```

`kubectl apply -f httpd.yml`
`kubectl get deployment -n leandrom`
`kubectl get pods -n leandrom`
`kubectl delete pod httpd-68d6cfbc7d-4f7hg -n leandrom`
`kubectl edit deployment httpd -n leandrom`
`kubectl describe deployment -n leandrom`
`kubectl describe pod httpd-68d6cfbc7d-tcw75 -n leandrom` (to get POD Internal IP Address)


## Services

Each pod in a deployment has its own IP, however due to the dynamic nature of the clusters, pods can change along with their IPs so we can’t just rely on any static configuration. Fortunately Kubernetes has this covered by the Service resource.

A Kubernetes service is like a routing solution inside the cluster. It exposes all the pods belonging to a deployment, statefulset or daemonset under a static IP and DNS name and it is immediately updated if pods change. Services identify the member pods by labels.

Kubernetes also has an internal DNS server and every service receives a unique name in the form:

`<servicename>.<namespace>.svc.cluster.local`


`kubectl get service -n leandrom`
`kubectl describe svc helloworld -n leandrom`

```yaml
---
apiVersion: v1
kind: Service
metadata:
  name: helloworld
  namespace: leandrom
spec:
  type: ClusterIP
  selector:
    mypod: httpd_pod
  ports:
    - port: 80
      targetPort: 80
```

`kubectl run debian --image debian -n leandrom -- sleep infinity`
`kubectl exec -ti debian -n leandrom -- bash`
`apt-get update`
`apt-get install -y curl`
`curl helloworld.leandrom.svc.cluster.local`

## Ingress
https://kubernetes.io/docs/concepts/services-networking/ingress/
`kubectl get ingress -n leandrom`

```
---
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: helloworld
  namespace: leandrom
  annotations:
    nginx.ingress.kubernetes.io/force-ssl-redirect: "true"
    nginx.ingress.kubernetes.io/rewrite-target: "/"
spec:
  ingressClassName: sandbox-nlb
  rules:
  - host: helloworld.sandbox.au.humanforce.com
    http:
      paths:
      - backend:
          service:
            name: helloworld
            port:
              number: 80
        path: /leandrom
        pathType: Prefix
```

`kubectl get pods -n leandrom`
`kubectl exec -ti httpd-68d6cfbc7d-nmhg8 -n leandrom -- bash`
`# echo '<html><body><h1>Hello World Leo!</h1></body></html>' > htdocs/index.html` `# cat htdocs/index.html`

## POD Example 
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: httpd
  namespace: leandrom
  labels:
    app: httpd_app
spec:
  replicas: 1
  selector:
      matchLabels:
        mypod: httpd_pod
  template:
    metadata:
      labels:
        mypod: httpd_pod
    spec:
      containers:
        - name: main
          image: httpd:latest
          ports:
            - containerPort: 80
---
apiVersion: v1
kind: Service
metadata:
  name: helloworld
  namespace: leandrom
spec:
  type: ClusterIP
  selector:
    mypod: httpd_pod
  ports:
    - port: 80
      targetPort: 80
---
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: helloworld
  namespace: leandrom
  annotations:
    nginx.ingress.kubernetes.io/force-ssl-redirect: "true"
    nginx.ingress.kubernetes.io/rewrite-target: "/"
spec:
  ingressClassName: sandbox-nlb
  rules:
  - host: helloworld.sandbox.au.humanforce.com
    http:
      paths:
      - backend:
          service:
            name: helloworld
            port:
              number: 80
        path: /leandrom
        pathType: Prefix
```

## Secrets

Secrets are resources holding a collection of key-value pairs. The most simple way to think about it is like a file with key-value pairs. Secrets can be clear or may be configured as opaque for a bit of obfuscation. More specialised secrets can be configured with third party backing solutions (i.e. Hashicorp Vault). The main objective of a secret is to be used as source for environment variables (but might be mounted as a file as well).

`kubectl get secrets -n leandrom`
`kubectl apply -f secrets.yml`
`kubectl describe secret safe -n leandrom`
`kubectl get secret safe -n leandrom -o yaml`
`kubectl get secret safe -n leandrom -o jsonpath='{.data}'` (this will show base64 encoded values)

`secrets.yml`

```
apiVersion: v1
kind: Secret
metadata:
  name: safe
  namespace: leandrom
type: Opaque
stringData:
  user: leandrom
  pass: "12345"
```

Consuming the secret

```
---
apiVersion: v1
kind: Pod
metadata:
  name: hello
  namespace: guimo
spec:
  containers:
    - name: main
      image: busybox
      command: ['sh', '-c', 'echo Hello $USER && sleep 10 && echo Bye!']
      env:
        - name: USER
          valueFrom:
            secretKeyRef:
              name: safe
              key: user
```

`kubectl apply -f secrets.yml`
`kubectl logs hello -n leandrom`
`kubectl describe pod hello -n leandrom` (environment variables don't show the secrets)

## Configmaps

ConfigMaps are used to keep your application code separate from your configuration. Configmaps are very similar to Secrets, indeed a configmap can do almost anything you can do with a secret and even more, however the configmap is never encrypted and not designed to store secret information like passwords or certificates.

Same as a secret, a configmap is a key value store with the difference a configmap value can be multiline and describe a whole file. You can use it to define env vars but the main purpose is allowing you to define a configuration you would like to be applied at pod startup by mounting those files in the pod.

For this example, we will replace the index.html from the httpd service we are running for a new file that comes from the configmap. To do this, we are going to use the httpd.yaml file we created in the last session. First make a copy of the httpd.yaml to configmap.yaml (just for safekeeping)

`cp httpd.yml configmap.yml`
add the below

```
---
apiVersion: v1
kind: ConfigMap
metadata:
  name: httpd
  namespace: guimo
data:
  index.html: |
    <html><body><h1>This file comes from my configmap</h1></body></html>
```

`kubectl apply -f configmap.yml -n leandrom`
`kubectl describe configmap httpd -n leandrom`

So we have a configmap, now we need to mount this to the container. Edit your configmap.yaml file in the Deployment definition so it looks like this:

```
apiVersion: apps/v1
kind: Deployment
metadata:
  name: httpd
  namespace: leandrom
  labels:
    app: httpd_app
spec:
  replicas: 1
  selector:
      matchLabels:
        mypod: httpd_pod
  template:
    metadata:
      labels:
        mypod: httpd_pod
    spec:
      containers:
        - name: main
          image: httpd:latest
          ports:
            - containerPort: 80
          volumeMounts:
          - name: index-config
            mountPath: /usr/local/apache2/htdocs
      volumes:
        - name: index-config
          configMap:
            name: httpd
```

`kubectl apply -f configmap.yml -n leandrom`
`curl https://helloworld.sandbox.au.humanforce.com/leandrom`

## Mounting persistent volumes

As mentioned before, Persistent volumes are used to keep data generated by a service. Just don’t get confused by the term “persistent”, given the dynamic nature of cloud resources, we can spawn a volume for a couple hours then terminate them once we are done. By doing this we are never constrained to the host node restrictions.

For example, a host node may have a 50GB disk, but we need to uncompress a file of about 100GB size, then we can spawn a 100GB volume, attach to the pod, run our process then release the volume.

Kubernetes uses two levels of abstraction of the underlying file storage to mount filesystems to the pod.

- Persistent Volume (pv) - Describes the resource in its most basic level backed by a real resource like an EBS volume, an EFS/NFS storage and similar. When a PV is created, a real volume is created in the cloud.
    
- Persistent Volume Claim (pvc) - Is a request of storage space. When a PVC is created, the cluster will look for PVs with matching attributes and reserve the requested space if available. PVCs are then attached to pods via volumeMounts. Kubernetes can detach and reattach a PV and PVC to the appropriate nodes following the pod that requires them.
    

Our clusters are configured with a dynamic provisioning that will automatically create a PV when a PVC is created, but it is possible to create the PV if you prefer a more fine grained control.

`kubectl get storageclass`
```
ebs-gp2         ebs.csi.aws.com         Delete          WaitForFirstConsumer   true  
gp2 (default)   kubernetes.io/aws-ebs   Delete          WaitForFirstConsumer   false 
```

`volume.yml`

```
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: bigdisk
  namespace: leandrom
spec:
  accessModes:
    - ReadWriteOnce
  storageClassName: ebs-gp2
  resources:
    requests:
      storage: 30Gi
```

`kubectl apply -f volume.yml`

### ## Init Containers

The idea of an init container is to execute some startup commands using public images without having to embed those commands into the main container image. As they work like regular pods, it is possible to mount shared filesystems or empty folders so they can write the command outputs for coordination; and as they are guaranteed to execute sequentially it is easy to coordinate the outputs as next step inputs.

`volumes.yml`

`kubectl delete pod volumes -n leandrom`
`kubectl apply -f volumes.yml`

```
apiVersion: v1
kind: Pod
metadata:
  name: volumes
  namespace: leandrom
spec:
  securityContext:
    runAsUser: 1000
    runAsGroup: 1000
    fsGroup: 1000
  initContainers:
    - name: download
      image: curlimages/curl:latest
      command: ['sh', '-c', "curl google.com -o /write/google.html"]
      volumeMounts:
        - mountPath: /write
          name: shared-volume
  containers:
    - name: app
      image: busybox:1.28
      command: ['sh', '-c', 'cat /read/google.html']
      volumeMounts:
        - mountPath: /read
          name: shared-volume
  volumes:
    - name: shared-volume
      emptyDir:
        sizeLimit: 100Mi
```
## References
https://kubernetes.io/docs/concepts/
[Kubernetes 101: Pods, Nodes, Containers, and Clusters](https://medium.com/google-cloud/kubernetes-101-pods-nodes-containers-and-clusters-c1509e409e16)
https://kubernetes.io/docs/concepts/overview/components/
https://12factor.net/ #Architecture 