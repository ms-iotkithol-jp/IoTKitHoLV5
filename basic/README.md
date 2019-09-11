# 基礎編 
Raspberry Pi で画像を撮影し、Cloud にアップロードして、Custom Vision で画像認識して、結果を Raspberry Pi に送信する 
![overall](/docs/images/basic/IoTKitHoLV5OV.png)
## Edge Side 
Raspberry Pi で画像を撮影し、Blob on Edge に格納する。 
Azure IoT Hub から送信されたテキストを SenseHat の LED マトリックスで表示する。 
![Edge Overall](/docs/images/basic/DeviceSideOV.png)  
とりあえず試したい場合、全て Build 済みのモジュールを使った場合の[deployment.template.json](./edge/deployment.published-image.template.json) を使うとよい。

参考 github repository : 
- [ms-iotkithol-jp/AzureIoTBlobOnEdgeSample](https://github.com/ms-iotkithol-jp/AzureIoTBlobOnEdgeSample)
## Cloud Side 
Custom Vision で自前の画像認識学習モデルを作成
Blob Container にアップロードされた画像ファイルを Custom Vision で画像認識
画像認識結果を Azure IoT Hub を通じて、画像をアップロードしてきた Raspberry Pi に JSON 形式で送信 
![Cloud Overall](/docs/images/basic/CloudSideOV.png)
参考 github repository :  
- Invoke Custom Vision - [ms-iotkithol-jp/AzureFunctionsBlobTriggerCustomVisionByPythonSample](https://github.com/ms-iotkithol-jp/AzureFunctionsBlobTriggerCustomVisionByPythonSample)  
- Send C2D Message - [ms-iotkithol-jp/AzureFunctionBlobTriggerIoTHubC2DMessageByCSSample](https://github.com/ms-iotkithol-jp/AzureFunctionBlobTriggerIoTHubC2DMessageByCSSample)