class jQuery  {
    constructor(str){
        this._string =str;
    }

    addClass(className){
        jQuery.addClass(this._string, className);
        return this;
    };

    static addClass(selector, className){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++ ) {
            elements[i].classList.add(className);
        }
    };

    removeClass(className){
        jQuery.removeClass(this._string, className);
        return this;
    }

    static removeClass(selector, className){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++ ) {
            elements[i].classList.remove(className);
        }
    };

    append(strHtml){
        jQuery.append(this._string, strHtml);
        return this;
    }

    static append(selector, strHtml){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++ ) {
            elements[i].insertAdjacentHTML('afterbegin', strHtml);
        }        
    };

    remove(){
        jQuery.remove(this._string);
        return this;
    }

    static remove(selector){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++ ){
            elements[i].parentNode.removeChild(elements[i]);
        }        
    };

    text(){
        return jQuery.text(this._string);
    }

    static text(node){
        let element = document.querySelector(node);
        if (element == null){
            return null;
        }
        return element.innerText;        
    };

    attr(attributeName, value){
        return jQuery.attr(this._string, attributeName, value);
    };

    //Get the value of an attribute for the first element in the set of matched elements
    //value != null set one or more attributes for every matched element.
    static attr(selector, attributeName, value){
        let element = document.querySelector(selector);
        if (element == null){
            return null;
        }

        if (value){
            element.setAtttibute(attributeName, value);
        }
        else{
            return element.getAttribute(attributeName);            
        }
    };

    children(selector){
        return new jQuery( jQuery.children(this._string, selector));
    }

    //Get the children of each element in the set of matched elements, optionally filtered by a selector.
    static children(node, selector){
        let element = document.querySelector(node);
        if (element == null){
            return null;
        }
        let result = [];
        if (!selector)
            return element.childNodes;

        for(let i = 0; i < element.childNodes.length; i++ ){            
            if (element.childNodes[i].nodeType == 1 && 
                (element.childNodes[i].matches == "undefined"
                ? element.childNodes[i].matches(selector)
                :element.childNodes[i].msMatchesSelector(selector)
                )){
                result.push(element.childNodes[i]);
            }
        }
        return result;
    };

    empty(){
        jQuery.empty(this._string);
        return;
    }

    //Remove all child nodes of the set of matched elements from the DOM.
    static empty(node){
        let element = document.querySelector(node);
        if (element == null){
            return null;
        }        
        while (element.firstChild){
            let child = element.firstChild;
            child.parentNode.removeChild( child);   
        }        
    };

    css(property){
        jQuery.css(this._string, property);
        return this;
    }

    static css(node, property){
        let element = document.querySelector(node);
        if (element == null){
            return null;
        }
        var regex = RegExp('^[a-z\-\ ]+:[a-z\ ]+$');
        if (!regex.test(property))
            return window.getComputedStyle(element).getPropertyValue(property);
        element.setAttribute("style", property);
    };

    click(callback){
        jQuery.click(this._string, callback);
        return this;
    }

    static click(node, callback){
        let element = document.querySelector(node);
        if (element == null){
            return null;
        }
        element.addEventListener('click', callback);
    };

    foreach(callback){
        jQuery.foreach(this._string, callback);
        return this;
    }

    static foreach(selector, callback){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++){
            callback.call(null, elements[i]);
        }
    }

    toggle(){
        jQuery.toggle(this._string);
        return this;
    }

    static toggle(selector){
        let elements = document.querySelectorAll(selector);
        for(let i = 0; i < elements.length; i++){
            elements[i].style.display = "none";
        }
    }
    
}

jQuery.addClass('body', 'katya');
jQuery.removeClass('body', 'katya');
jQuery.append('ul', '<li>SMILE one</li>');
jQuery.css('li', "background-color:blue");
jQuery.empty('ul');
console.log(jQuery.text('body'));

console.log(jQuery.children(".demo-container", 'ul'));
console.log(jQuery.attr(".demo-box", 'something'));

console.log(jQuery.css('body', 'background-color'));
console.log(jQuery.css('body', 'background-color: gray'));


jQuery.click('body', function() {
    alert("addEventListener"); 
  });

//jQuery.toggle('li');