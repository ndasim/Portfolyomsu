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
        sinif = 'tabla'
        
        child = false;
    
    this.outHeight = parseInt(height + (2*borderWidth));
    this.outWidth = parseInt(width + (2*borderWidth));
    
	this.tabla = veri;
    
    var tabla = {
            solust: styledNewElement(false, "tablaSolUst", "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; background-image: url('" + tempDir + "/solust." + tempExt + "');"),
            ust: styledNewElement(false, "tablaUst", "position:absolute; height: " + borderWidth + "px; width: " + (width + borderWidth) + "px; left: " + borderWidth + "px; background-image: url('" + tempDir + "/ust." + tempExt + "');"),
            sagust: styledNewElement(false, "tablaSagUst", "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; background-image: url('" + tempDir + "/sagust." + tempExt + "');"),
            sag:  styledNewElement(false, "tablaSag", "position:absolute; height: " + height + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/sag." + tempExt + "');"),
            sagalt:  styledNewElement(false, "tablaSagAlt", "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; left: " + (width + borderWidth) + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/sagalt." + tempExt + "');"),
            alt: styledNewElement(false, "tablaAlt", "position:absolute; height: " + borderWidth + "px; width: " + width + "px; left: " + borderWidth + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/alt." + tempExt + "');"),
            solalt: styledNewElement(false, "tablaSolAlt", "position:absolute; height: " + borderWidth + "px; width: " + borderWidth + "px; top:" + (height + borderWidth) + "px; background-image: url('" + tempDir + "/solalt." + tempExt + "');"),
            sol: styledNewElement(false, "tablaSol", "position:absolute; height: " + height + "px; width: " + borderWidth + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/sol." + tempExt + "');"),
            tabla: styledNewElement(false, "tablaTabla", "position:absolute; height: " + height + "px; width: " + width + "px; left: " + borderWidth + "px; top:" + borderWidth + "px; background-image: url('" + tempDir + "/tabla." + tempExt + "');"),
            fake: styledNewElement(false, "fake", "position:absolute; height: " + height + "px; width: " + width + "px; left: " + borderWidth + "px; top:" + borderWidth + "px;")
        }
	
    this.obje = styledNewElement(id, sinif, '');
    
	this.kur = function() {
                    id = typeof this.tabla.id != "undefined" ? this.tabla.id : id;               				
                    height = parseInt(typeof this.tabla.height != "undefined" ? this.tabla.height : height);               				      
                    width = parseInt(typeof this.tabla.width != "undefined" ? this.tabla.width : width);               
                    tempDir = typeof this.tabla.tempDir != "undefined" ? this.tabla.tempDir : tempDir;
                    tempExt = typeof this.tabla.tempExt != "undefined" ? this.tabla.tempExt : tempExt;     
                    border = parseInt(typeof this.tabla.borderWidth != "undefined" ? this.tabla.borderWidth : borderWidth);              
                    style = typeof this.tabla.style != "undefined" ? this.tabla.style : style;
                    
                    tabla = {
                        solust: styledNewElement(false, "tablaSolUst", "position:absolute; height: " + border + "px; width: " + border + "px; background-image: url('" + tempDir + "/solust." + tempExt + "');"),
                        ust: styledNewElement(false, "tablaUst", "position:absolute; height: " + border + "px; width: " + width + "px; left: " + border + "px; background-image: url('" + tempDir + "/ust." + tempExt + "');"),
                        sagust: styledNewElement(false, "tablaSagUst", "position:absolute; height: " + border + "px; width: " + border + "px; left: " + (width + border) + "px; background-image: url('" + tempDir + "/sagust." + tempExt + "');"),
                        sag:  styledNewElement(false, "tablaSag", "position:absolute; height: " + height + "px; width: " + border + "px; left: " + (width + border) + "px; top:" + border + "px; background-image: url('" + tempDir + "/sag." + tempExt + "');"),
                        sagalt:  styledNewElement(false, "tablaSagAlt", "position:absolute; height: " + border + "px; width: " + border + "px; left: " + (width + border) + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/sagalt." + tempExt + "');"),
                        alt: styledNewElement(false, "tablaAlt", "position:absolute; height: " + border + "px; width: " + width + "px; left: " + border + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/alt." + tempExt + "');"),
                        solalt: styledNewElement(false, "tablaSolAlt", "position:absolute; height: " + border + "px; width: " + border + "px; top:" + (height + border) + "px; background-image: url('" + tempDir + "/solalt." + tempExt + "');"),
                        sol: styledNewElement(false, "tablaSol", "position:absolute; height: " + height + "px; width: " + border + "px; top:" + border + "px; background-image: url('" + tempDir + "/sol." + tempExt + "');"),
                        tabla: styledNewElement(false, "tablaTabla", "position:absolute; height: " + height + "px; width: " + width + "px; left: " + border + "px; top:" + border + "px; background-image: url('" + tempDir + "/tabla." + tempExt + "');"),
                        fake: styledNewElement(false, "fake", "position:absolute; height: " + height + "px; width: " + width + "px; left: " + border + "px; top:" + border + "px;")
                    }
                    
                    //////
                    this.obje = styledNewElement(id, sinif, style);
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
                    this.obje.appendChild(tabla.fake);
                    //return this.obje;
                };
    
	this.boyutla = function() {};
	this.icerikGir = function() {};
    
    this.tempDegis = function() {};
    
    this.appendChild = function(child){
                            try{this.obje.removeChild(tabla.fake)}catch(e){};
                            tabla.fake.appendChild(child);
                            this.obje.appendChild(tabla.fake);
                            //this.obje.appendChild(child);
                        };
}

function newAttr(attrName, nodeValue){
    var attr = document.createAttribute(attrName);
    attr.nodeValue = nodeValue;
    return attr;
}

function styledNewElement(id, sinif, style){
    var obje = document.createElement('div');
    if(id){obje.attributes.setNamedItem(newAttr('id', id))};
    if(sinif){obje.attributes.setNamedItem(newAttr('class', sinif))};
    if(sinif){obje.attributes.setNamedItem(newAttr('class', sinif))};
    obje.attributes.setNamedItem(newAttr('style', style));
    return obje;
}