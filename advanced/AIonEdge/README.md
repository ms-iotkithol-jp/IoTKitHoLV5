# AI on Edge 
とりあえず試したい場合は、[deployment.json](./deployment.json)  を、VS Code や Azure CLI でデプロイして、お試しください。 
## ※参考 ‐ Azure CLI でデプロイ 
参考URL ‐ [https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-deploy-modules-cli](https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-deploy-modules-cli)  
Azure CLI に IoT Extension をインストール 
```script
az extension add --name azure-cli-iot-ext
```
Azure にサインイン 
```script
az login
```

モジュール配置情報を IoT Hub に送信する 
```script
az iot edge set-modules --device-id [device id] --hub-name [hub name] --content ./deployment.json
```
これで、IoT Hub を通じて IoT Edge に配置情報が送信され、IoT Edge Runtime がモジュールをプルして実行が開始される。