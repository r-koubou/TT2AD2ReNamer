## TT2ADReNamer ##

![](http://i.imgur.com/ytj4LpG.png?1)

※ 日本語の説明は英語の後に記載しています。

Executable Binary download from [HERE](https://github.com/r-koubou/TT2AD2ReNamer/raw/master/dist/TT2ADReNamer.zip)

[What's this?]

Toontrack EZdrummer's midi groove file name converts to Addictive Drums2 External midi file name specification.
Maybe EZX, SDX, Superior, MIDI Pack can convert.
I tested follwing EZX / SDX midi groove files.

    EZX AMERICANA
    EZX CLAUSTROPHOBIC
    EZX DRUM KIT FRON HELL
    EZX ELECTRONIC
    EZX FUNKMASTERS
    EZX INDIE FOLK
    EZX JAZZ
    EZX LATAIN PERCUSSION
    EZX MADE OF METAL
    EZX METAL HEADS
    EZX METAL MACHINE
    EZX METAL!
    EZX NASHVILLE
    EZX NUMBER 1 HITS
    EZX POP
    EZX POP ROCK
    EZX ROCK SOLID
    EZX ROCK!
    EZX THE BLUES
    EZX THE CLASSIC
    EZX TWISTED KIT
    EZX VINTAGE ROCK
    SDX METAL MACHINERY


[Require]

* Windows User: Latest .net Framework
* Mac User: Latest Mono Framework


[STEP]

1. Copy Folder `<Installed to EZdrummer>/Midi/` to temporary folder.
2. Convert midi mapping to AD2.
3. Use this tool from Command Prompt@Win / Terminal@Mac.

e.g.

    Windows user
    TT2ADReNamer.exe <config json file> <source midi folder> <destination folder>
    
    Mac user
    mono TT2ADReNamer.exe <config json file> <source midi folder> <destination folder>

        config json file:
                You can use conf/*.json. If you tries other EZX / SDX, You make a json file ( Format is very simple! )

        source midi folder:
                e.g. EZX Metal Machine:
                18@EZX_METAL_MACHINE

        destination folder:
                Create converted folder.
                Copy to "the AD2 External MIDI Folder"
                And refresh files（On AD2: ? -> Refresh MIDI Library）

*NOTE*

1.
NOT INCLUDED MIDI FILES.
This program CONVERTS FILE NAME ONLY!.

2.
You need convert mapping your MIDIFILE.
I found convert mapping tool -> [https://midifilemapper.codeplex.com/]("https://midifilemapper.codeplex.com/")

[License]

See source code.

----------

実行バイナリファイルのダウンロードは[こちらから](https://github.com/r-koubou/TT2AD2ReNamer/raw/master/dist/TT2ADReNamer.zip)

[これは何？]

Toontrack EZdrummer シリーズの midi グルーブファイル名を Addictive Drums2 の書式に変換します。
多分他の EZX, SDX, Superior, MIDI Pack も出来ると思います。
テストを行った物は以下のEZX、SDX。

    EZX AMERICANA
    EZX CLAUSTROPHOBIC
    EZX DRUM KIT FRON HELL
    EZX ELECTRONIC
    EZX FUNKMASTERS
    EZX INDIE FOLK
    EZX JAZZ
    EZX LATAIN PERCUSSION
    EZX MADE OF METAL
    EZX METAL HEADS
    EZX METAL MACHINE
    EZX METAL!
    EZX NASHVILLE
    EZX NUMBER 1 HITS
    EZX POP
    EZX POP ROCK
    EZX ROCK SOLID
    EZX ROCK!
    EZX THE BLUES
    EZX THE CLASSIC
    EZX TWISTED KIT
    EZX VINTAGE ROCK
    SDX METAL MACHINERY


[必要な環境]

* Windowsユーザー：最新の .net Framework
* Macユーザー：最新の Mono Framework

[使い方]

1. `<EZdrummerインストール先>/Midi` を一時フォルダにコピー
2. AD2のMIDIマッピングに変換
3. このツールでファイル名の変換コマンドプロンプト(Windows)/ターミナルを使用します

e.g.

    Windowsユーザー
    TT2ADReNamer.exe <config json file> <source midi folder> <destination folder>
    
    Macユーザー
    mono TT2ADReNamer.exe <config json file> <source midi folder> <destination folder>

        config json file:
                conf/*.json をお使い下さい。
                必要であれば新規に自分でファイルも作成できます。JSONの文法は書式は非常に簡単です。

        source midi folder:
                e.g. EZX Metal Machine:
                18@EZX_METAL_MACHINE

        destination folder:
                変換後のフォルダが作成されます。
                AD2の External MIDI Folder フォルダにコピーし、リロード（AD2上で、? -> Refresh MIDI Library）して下さい。

*注意*
* 当然ですがMIDIファイルは含まれません。このツールはファイル名変換のみです。


* 別途マッピング変換が必要です。
* こういったツールがあるようです -> https://midifilemapper.codeplex.com/

[ライセンス]

ソースコードを見て下さい。
