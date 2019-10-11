# CLIでサクッと  
[基本知識](https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-deploy-monitor-cli)  
まず、[/basic/edge/deployment.published-image.template.json](/basic/edge/deployment.published-image.template.json)のlocal-blob-storage、store-image-to-local-blobモジュールのBlob周りのセキュリティ情報を設定して、deployment.jsonという名前で、Azure CLIのシェルから参照できる場所を保存します。 

作成したdeployment.jsonを、[https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-deploy-monitor-cli#create-a-deployment](https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-deploy-monitor-cli#create-a-deployment)に書いてある方法で、IoT Edge側のモジュール構成を設定できます。 
