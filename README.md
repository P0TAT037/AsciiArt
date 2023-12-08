# AsciiArt

## Command Line Options

    [] => required argument

    {} => optional argument

### Show help

- `asciiart -h` or `asciiart --help`

### Draw an image

- `asciiart -i [image path] {image width}`

### Draw a video

- `asciiart -v [path] {video width} {sleep between frames in ms}`

### Live Capture

- `asciiart -l {video width}` or `asciiart --live {video width}`

### Draw Text

- `-asciiart t [text] {fontname}`

  - New fonts can be added and used by providing its path in the `{fontname}` parameter

  - [Download new fonts [here](https://github.com/xero/figlet-fonts/tree/master)]

- `asciiart --fonts`
  - Lists all font names
- `asciiart -t -r [text]`
  - Draw text with a random font
- `asciiart -t -d [text]`
  - Draw text with the default decoration
- `asciiart -t --decorate [text]`
  - Draw text with a custom decoration
