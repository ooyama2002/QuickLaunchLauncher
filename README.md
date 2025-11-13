# Quick Launch Launcher
## Quick Launch Launcherについて
- [Quick Launch Launcher]は、Windows7/10の頃のQuick Launchの代りとして作成したランチャープログラムです。
- 起動すると画面中央下に[Launch]画面が表示されます。  
  ![Launch画面](https://github.com/user-attachments/assets/604d180c-59e8-4dc3-8805-a7d96b666e0f)
- [Launch]画面をクリックすると、[Quick Launch]フォルダのショートカットを表示します。  
  ![Quick Launch表示](https://github.com/user-attachments/assets/7e2dee18-6313-48db-9e5f-51fe0a98c46f)
- [Quick Launch]フォルダの場所は、エクスプローラのアドレスで```shell:Quick Launch```と入力すると表示され  
  ```C:\Users\[user]\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch```  
  となります。

## システムメニューについて
- 表示されるメニューの下の[System Menu]の内容は以下の通りです。

| 項目                     | 説明                                               |
| ------------------------ | -------------------------------------------------- |
| Open Quick Launch Folder | [Quick Launch]フォルダを開きます                   |
| Refresh                  | [Quick Launch]フォルダを読み込みなおして表示します |
| Setting                  | 設定画面を開きます                                 |
| Quit                     | アプリケーションを終了します                       |

## 設定画面について
- 設定画面では[Launch]画面の配置と背景画像の設定ができます。  
  ![設定画面](https://github.com/user-attachments/assets/a53227e5-6532-406a-9bf0-10779047616c)

## 起動引数について
- [Quick Launch]フォルダ以外から表示したい場合はショートカットを作成して起動引数でフォルダを指定します。
- 例えばプログラムフォルダの内容を表示したい場合はショートカットの引数を以下のようにします。  
  ```QuickLaunchLauncher.exe "C:\ProgramData\Microsoft\Windows\Start Menu\Programs"```
