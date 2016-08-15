// asim.dogan.namli@gmail.com // 01.09.2014 17:30 //

var otoid = 0;

function tabla(veri) {
	var id = 'tabla' + (++otoid),
		height = 100,
		width = 100,
		
		tempDir = 'tabla',
        tempExt = 'gif',
		borderWidth = 10,
		
		style = 'position: relative',
        
        child = false;
    
    this.outHeight = parseInt(height + (2*borderWidth));
    this.outWidth = parseInt(width + (2*borderWidth));
    
	this.tabla = veri;
    
    var tabla = {
            solust: styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; background-image: url('" + tempDir + "/solust." + tempExt + "');"),
            ust: styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + (width + borderWidth) + "px; left: " + borderWidth + "px; background-image: url('" + tempDir + "/ust." + tempExt + "');"),
            sagust: styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; background-image: url('" + tempDir + "/sagust." + tempExt + "');"),
            sag:  styledNewElement(false, "position:absolute; height: " + height + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/sag." + tempExt + "');"),
            sagalt:  styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/sagalt." + tempExt + "');"),
            alt: styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + width + "px; left: " + borderWidth + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/alt." + tempExt + "');"),
            solalt: styledNewElement(false, "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/solalt." + tempExt + "');"),
            sol: styledNewElement(false, "position:absolute; height: " + height + "px; width: " + borderWidth + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/sol." + tempExt + "');"),
            tabla: styledNewElement(false, "position:absolute; height: " + height + "px; width: " + width + "px; left: " + borderWidth + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/tabla." + tempExt + "');")
        }
	
    this.obje = styledNewElement(id, '');
    
	this.kur = function() {
                    id = typeof this.tabla.id != "undefined" ? this.tabla.id : id;               				
                    height = parseInt(typeof this.tabla.height != "undefined" ? this.tabla.height : height);               				      
                    width = parseInt(typeof this.tabla.width != "undefined" ? this.tabla.width : width);               
                    tempDir = typeof this.tabla.tempDir != "undefined" ? this.tabla.tempDir : tempDir;
                    tempExt = typeof this.tabla.tempExt != "undefined" ? this.tabla.tempExt : tempExt;     
                    border = parseInt(typeof this.tabla.borderWidth != "undefined" ? this.tabla.borderWidth : borderWidth);              
                    style = typeof this.tabla.style != "undefined" ? this.tabla.style : style;
                    
                    var tabla = {
                        solust: styledNewElement(false, "position:absolute; height: " + border + "px; width: " + border + "px; background-image: url('" + tempDir + "/solust." + tempExt + "');"),
                        ust: styledNewElement(false, "position:absolute; height: " + border + "px; width: " + width + "px; left: " + border + "px; background-image: url('" + tempDir + "/ust." + tempExt + "');"),
                        sagust: styledNewElement(false, "position:absolute; height: " + border + "px; width: " + border + "px; left: " + (width + border) + "px; background-image: url('" + tempDir + "/sagust." + tempExt + "');"),
                        sag:  styledNewElement(false, "position:absolute; height: " + height + "px; width: " + border + "px; left: " + (width + border) + "px; top:" + border + "px; background-image: url('" + tempDir + "/sag." + tempExt + "');"),
                        sagalt:  styledNewElement(false, "position:absolute; height: " + border + "px; width: " + border + "px; left: " + (width + border) + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/sagalt." + tempExt + "');"),
                        alt: styledNewElement(false, "position:absolute; height: " + border + "px; width: " + width + "px; left: " + border + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/alt." + tempExt + "');"),
                        solalt: styledNewElement(false, "position:absolute; height: " + border + "px; width: " + border + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/solalt." + tempExt + "');"),
                        sol: styledNewElement(false, "position:absolute; height: " + height + "px; width: " + border + "px; top:" + border + "px; background-image: url('" + tempDir + "/sol." + tempExt + "');"),
                        tabla: styledNewElement(false, "position:absolute; height: " + height + "px; width: " + width + "px; left: " + border + "px; top:" + border + "px; background-image: url('" + tempDir + "/tabla." + tempExt + "');")
                    }
                    
                    //////
                    this.obje = styledNewElement(id, style);
                    this.obje.style.height = parseInt(height + (2*border));
                    this.obje.style.width = parseInt(width + (2*border));
                    //////
                    this.obje.appendChild(tabla.alt);
                    this.obje.appendChild(tabla.ust);
                    this.obje.appendChild(tabla.sag);
                    this.obje.appendChild(tabla.sagalt);
                    this.obje.appendChild(tabla.sagust);
                    this.obje.appendChild(tabla.sol);
                    this.obje.appendChild(tabla.solalt);
                    this.obje.appendChild(tabla.solust);
                    this.obje.appendChild(tabla.tabla);
                    //return this.obje;
                };
    
	this.boyutla = function() {};
	this.icerikGir = function() {};
    
    this.tempDegis = function() {};
    
    this.appendChild = function(child){
                            //this.obje.removeChild(tabla.tabla);
                            tabla.tabla.appendChild(child);
                            this.obje.appendChild(tabla.tabla);
                        };
}

function newAttr(attrName, nodeValue){
    var attr = document.createAttribute(attrName);
    attr.nodeValue = nodeValue;
    return attr;
}

function styledNewElement(id, style){
    var obje = document.createElement('div');
    if(id){obje.attributes.setNamedItem(newAttr('id', id))};
    obje.attributes.setNamedItem(newAttr('style', style));
    return obje;
}