# Quick Launch Launcher
## Quick Launch Launcherについて
- [Quick Launch Launcher]は、Windows7/10の頃のQuick Launchの代りとして作成したランチャープログラムです。
- 起動すると画面中央下に[Launch]画面が表示されます。  
  ![Launch画面](https://private-user-images.githubusercontent.com/176577467/513593261-604d180c-59e8-4dc3-8805-a7d96b666e0f.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjI5OTQ4NDIsIm5iZiI6MTc2Mjk5NDU0MiwicGF0aCI6Ii8xNzY1Nzc0NjcvNTEzNTkzMjYxLTYwNGQxODBjLTU5ZTgtNGRjMy04ODA1LWE3ZDk2YjY2NmUwZi5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMTEzJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTExM1QwMDQyMjJaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT0yYzViYmJhNzhmOTE5NTE3M2Y0Njk1N2EyMGFmNTU4NDJlZTkzYWY1MDM4MzM0YjEyYzA3Njk5YzQyNmQ1NDFjJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.lxnIQ1Nj46BT9rDDDG3M7uVqRz9XXDYqdWnb681lnAs)
- [Launch]画面をクリックすると、[Quick Launch]フォルダのショートカットを表示します。  
  ![Quick Launch表示](https://private-user-images.githubusercontent.com/176577467/513593305-7e2dee18-6313-48db-9e5f-51fe0a98c46f.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjI5OTQ4NDIsIm5iZiI6MTc2Mjk5NDU0MiwicGF0aCI6Ii8xNzY1Nzc0NjcvNTEzNTkzMzA1LTdlMmRlZTE4LTYzMTMtNDhkYi05ZTVmLTUxZmUwYTk4YzQ2Zi5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMTEzJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTExM1QwMDQyMjJaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1lMTE4ZWNlM2FkYzRmN2E4MjRjYWZiMzgxMTIzODMyZTdhODE4MTk3NGJiY2MzYmI2ZGI1MTQ5NTljZmVmMzE1JlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.NrTFREjxGDOudPjADqhk3yW2bPPk0IOm7urMaaV-n6s)
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
  ![設定画面](https://private-user-images.githubusercontent.com/176577467/513593350-a53227e5-6532-406a-9bf0-10779047616c.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjI5OTQ4NDIsIm5iZiI6MTc2Mjk5NDU0MiwicGF0aCI6Ii8xNzY1Nzc0NjcvNTEzNTkzMzUwLWE1MzIyN2U1LTY1MzItNDA2YS05YmYwLTEwNzc5MDQ3NjE2Yy5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMTEzJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTExM1QwMDQyMjJaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT01NzNkNzI3YjQwNWRlNmVjNjk2M2I0OWVmYzZmMTM1NWFjY2ExOTkyY2Y4NWJlMjcwNjMyMDE0YzU5NGFlNzJkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.9HswXYhZ5F4kpSXjRPwCQq7at-FlwdDNbW4DJf_0g1Y)

## 起動引数について
- [Quick Launch]フォルダ以外から表示したい場合はショートカットを作成して起動引数でフォルダを指定します。
- 例えばプログラムフォルダの内容を表示したい場合はショートカットの引数を以下のようにします。  
  QuickLaunchLauncher.exe "C:\ProgramData\Microsoft\Windows\Start Menu\Programs"
