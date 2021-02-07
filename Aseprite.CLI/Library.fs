namespace Aseprite

open Argu

module CLI =
        
    type Arguments =
        | Shell
        | [<AltCommandLine("-b")>] Batch
        | [<AltCommandLine("-p")>] Preview
        | Save_As of filename:string
        | Palette of filename:string
        | Scale of factor:float
        | Dithering_Algorithm of algorithm:string
        | Dithering_Matrix of matrix:string
        | Color_Mode of mode:string
        | Data of filename:string
        | Format of format:string
        | Sheet of filename:string
        | Sheet_Type of sheetType:string
        | Sheet_Width of pixels:int
        | Sheet_Height of pixels:int
        | Sheet_Columns of columns:int
        | Sheet_Rows of rows:int
        | Sheet_Pack
        | Split_Layers
        | Split_Tags
        | Split_Slices
        | [<AltCommandLine("--import-layer")>] Layer of name:string
        | All_Layers
        | Ignore_Layer of name:string
        | [<AltCommandLine("--frame-tag")>] Tag of name:string
        | Frame_Range of from:int * to':int
        | Ignore_Empty
        | Border_Padding of value:int
        | Shape_Padding of value:int
        | Inner_Padding of value:int
        | Trim
        | Crop of x:int * y:int * width:int * height:int
        | Slice of name:string
        | Filename_Format of fmt:string
        | Script of filename:string
        | Script_Param of kv:string
        | List_Layers
        | List_Tags
        | List_Slices
        | Oneframe
        | [<AltCommandLine("-v")>] Verbose
        | Debug
        | Version        
        
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Shell -> "Start an interactive console to execute scripts"
                | Batch -> "Do not start the UI"
                | Preview -> "Do not execute actions, just print what will be done"
                | Save_As _ -> "Save the last given sprite with other format"
                | Palette _ -> "Change the palette of the last given sprite"
                | Scale _ -> "Resize all previously opened sprites"
                | Dithering_Algorithm _ -> "Dithering algorithm used in --color-mode to convert images from RGB to Indexed"
                | Dithering_Matrix _ -> "Matrix used in ordered dithering algorithm"
                | Color_Mode _ -> "Change color mode of all previously opened sprites: (rgb, grayscale, indexed)"
                | Data _ -> "File to store the sprite sheet metadata"
                | Format _ -> "Format to export the data file (json-hash, json-array)"
                | Sheet _ -> "Image file to save the texture"
                | Sheet_Type _ -> "Algorithm to create the sprite sheet: (horizontal, vertical, rows, columns, packed)"
                | Sheet_Width _ -> "Sprite sheet width"
                | Sheet_Height _ -> "Sprite sheet height"
                | Sheet_Columns _ -> "Sprite sheet columns"
                | Sheet_Rows _ -> "Sprite sheet rows"
                | Sheet_Pack -> "Use a packing algorithm to avoid waste of space in the texture" 
                | Split_Layers -> "Import each layer of the next given sprite as a separated image in the sheet"
                | Split_Tags -> "Save each tag as a separated file"
                | Split_Slices -> "Save each slice as a separated file"
                | Layer _ -> "Include just the given layer in the sheet"
                | All_Layers -> "Make all layers visible. By default hidden layers will be ignored"
                | Ignore_Layer _ -> "Exclude the given layer in the sheet or save as operation"
                | Tag _ -> "Include tagged frames in the sheet"
                | Frame_Range _ -> "Only export frames in the [from,to] range"
                | Ignore_Empty -> "Do not export empty frames/cels"
                | Border_Padding _ -> "Add padding on the texture borders"
                | Shape_Padding _ -> "Add padding between frames"
                | Inner_Padding _ -> "Add padding inside each frame"
                | Trim -> "Trim all images before exporting"
                | Crop _ -> "Crop all the images to the given rectangle (x,y,width,height)"
                | Slice _ -> "Crop the sprite to the given slice area"
                | Filename_Format _ -> "Special format to generate filenames"
                | Script _ -> "Execute a specific script"
                | Script_Param _ -> "Parameter for a script executed from the CLI that you can access with app.params"
                | List_Layers -> "List layers of the next given sprite or include layers in JSON data"
                | List_Tags -> "List tags of the next given sprite sprite or include frame tags in JSON data"
                | List_Slices -> "List slices of the next given sprite sprite or include slices in JSON data"
                | Oneframe -> "Load just the first frame"
                | Verbose -> "Explain what is being done"
                | Debug -> "Extreme verbose mode and copy log to desktop"
                | Version -> "Output version information and exit"   
                
    let parser = ArgumentParser.Create<Arguments>(programName = "aseprite.exe")
    