# AI on Edge 
とりあえず試したい場合は、[deployment.cli.json](./deployment.cli.json)  を、VS Code や Azure CLI でデプロイして、お試しください。 
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
IoT Edge Module群は、以下のように配置される。 
![modules](/docs/images/advanced/AIonEdge/cissarch.png)

## おまけ 
camera-captureモジュールが、/dev/video0がないので動けまへん的なログを吐いていたら、以下のコマンドを実行して、IoT Edge Runtimeを再起動してください。 
※USB接続のWeb Camを使っているときには起きないようですね。。。 
```script
$ sudo modprobe bcm2835-v4l2
$ sudo systemctl restart iotedge
```
これ、ラズパイが起動するたびに毎回やらないといけないので、面倒だなと思う方は、/etc/rc.local の exit 0の行の前に、modprobeの実行を入れれば、起動時自動的に実行されるようになるのでやってみてね。 

## さらにおまけ 
ラズパイとカメラしかないんだよね。。。って人向けに、SenseHatなしでも動くバージョン。上記と同じCLIでデプロイするdeployment.json  
[deployment.cli.no-sensehat.json](./deployment.cli.no-sensehat.json)
