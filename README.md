# desktopBlazorWAKicker
Kick a Blazor WebAssembly app in local env from command line

# 概要
　ローカルファイルとして存在するBlazor WebAssemblyの実行ファイルをローカル上実行します。
　desktopBlazorWAKickerは簡易HTTPサーバとして機能し、Webブラウザを自動起動します。

# 環境
.NET 6がインストールされているWindows 10/11
(LinuxとMacへの対応コードは入っているので運が良ければ動く)

# 終了方法
Enterキーを押す
(起動されたWebブラウザは自動的に閉じないので好きなように終了する)

# コマンドライン
usage: desktopBlazorWAKicker [[portNumber] blazorProgramRoot]

第1引数　ポート番号。省略時のデフォルトは19190。
第2引数　Blazor WebAssemblyのアプリのルート(index.htmlのあるディレクトリ)。省略時のデフォルトはカレントディレクトリ

例1: desktopBlazorWAKicker
例2: desktopBlazorWAKicker 10109
例3: desktopBlazorWAKicker 10301 "C:\directory\wasm\wwwroot"

# 基本的な利用の考え方
同じディレクトリにBlazor WebAssemblyのアプリとdesktopBlazorWAKickerを入れておき、desktopBlazorWAKickerをオプションなしで起動することを基本とする。
他の用途とポートが当たる場合はポート番号を指定する

# 特記事項
本ソフトを実行するには管理者権限が必要です。(一般ユーザー権限では動作しないAPIを使用しているため)
問題なければ、本ツールを使うよりも、クラウドにデプロイしてPWAとしてデスクトップで使う方がベター。
