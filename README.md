# Style Script Inlining Tag Helper
MVC Razor Tag Helper that inlines stylesheets and scripts into HTML markup.

### Installation
1. Place your script and sytlesheet files into your webroot directory, which is typically `wwwroot`.
2. Add the Tag Helper `inline="true"` to any style or script tag where you would like inlining to occur.

### Example
Provided in the original markup:
```html
<style type="text/css" inline="true" src="styles-min.css"></style>
<script type="text/javascript" inline="true" src="scripts-min.js"></script>
```
The Tag Helper will read the file contents into the tags when producing outputs.
```html
<style type="text/css">h1,h2{color:#6d6d6d} ... h1{font-weight:300;font-family:sans-serif}</style>
<script type="text/javascript">function l(t){n.css("left",100*-t+"%")} ... function c(t){setTimeout(function(){s(t)},1e3)}</script>
```

### Version History
Version | Changes Made
------- | ------------
1.0.0   | Initial Release
