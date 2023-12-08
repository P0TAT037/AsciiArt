# AsciiArt

## Command Line Options

    [] => required argument

    {} => optional argument

### Show help

- `--help` Or `-h`

### Draw an image

- ` -i [image path] {image width} `

### Draw a video

- `-v [path] {width} {sleep}`

### Live Capture

- `-l {width}` OR `--live {width}`

### Draw Text

- `-t [text] {fontname}`

  - New fonts can be added and used by providing its path in the `{fontname}` parameter

  - [Download new fonts [here](https://github.com/xero/figlet-fonts/tree/master)]

- `--fonts`
  - Lists all font names
- `-t -r [text]`
  - Text with random font
- `-t -d [text]`
  - Text with the default decoration
- `-t --decorate [text]`
  - Text with custom decoration
