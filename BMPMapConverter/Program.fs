// Learn more about F# at http://fsharp.org

open System
open System.Drawing;
open Newtonsoft.Json
open Microsoft.FSharp.Collections;
open System.IO;
open Newtonsoft.Json.Linq

type Symbol = 
    {rgb: Color
     ch: string}
      
[<EntryPoint>]
let main argv =
    //Read symbols file
    let json = File.ReadAllText(argv.[1]);
    let token = JObject.Parse(json).SelectToken("symbols")
    let symbols = JsonConvert.DeserializeObject<List<Symbol>>(token.ToString())
    //Create bitmap
    let map = new Bitmap(argv.[0])
    for y in 0..(map.Width - 1) do
        for x in 0..(map.Height - 1) do
            for symbol in symbols do
                //Match rgb values to symbol colors
                if map.GetPixel(x,y) = symbol.rgb then
                    printf "%s" symbol.ch
        printfn("")

    
    0


