# 工科軟體設計89~112
這是一個 C# 競賽的項目。
> 時隔快一年把本人高二到高三比賽結束所做的程式再做修改，因為新買的筆電螢幕尺存較大「您主要顯示畫面的縮放比例設定為 150%」，執行Windows Form時會遇到字體模糊、放大、元件位置在錯的地方等等的問題，本人透過[程式碼修改 DPI 感知](https://github.com/chen199940/NOTE/blob/main/Windows%20Form%E5%B0%BA%E5%AF%B8%E5%95%8F%E9%A1%8C.md)解決。軟體設計近年有開始偏向單純演算法題目例如 111-1 矩陣結合快速冪實作費式數列，以本人經驗為例如果沒有先備知識考試當下多少會卡住，想說「費式數列就這一項等於前兩項相加的和，有什麼難?」常常自認為已經通盤了解的東西，不求甚解，卻遺漏些重要知識，當下想法浮出「你行你上啊!」。
## 專案類型
* Windows Forms App (C#)
* 主控台應用程式 (C#)
## 函式庫
會用的函式庫，舉少部分物件、語法的例子。
* using System.Collections.Generic;
> 常用的資料結構，如物件：List、Dictionary、HashSet 等。
* using System/Linq;
> LINQ 查詢運算式，如語法：from...select...、Enumerable.OrderBy。
* using System.IO;
> 讀取/寫入/選取檔案，如物件：StreamReader、StreamWriter。
* using System.Numerics;
> 處理大數問題，如物件：BigInteger。
* using System.Drawing;
* using System.Drawing2D;
> 表單應用程式畫圖形，如物件：Bitmap、Graph、Point。
## 小工具
可能會考其他的，基本上都要會 ; )
* Textbox
* RichTextBox
* Button
* Label
* ListBox
* PictureBox
* RadioButton
* GroupBox
* MenuStrip
* NumericUpDown
* OpenFileDialog
* SaveFileDialog
* Panel