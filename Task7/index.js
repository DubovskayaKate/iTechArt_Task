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
        for(let element of elements ) {
            element.classList.add(className);
        }
    };

    removeClass(className){
        jQuery.removeClass(this._string, className);
        return this;
    }

    static removeClass(selector, className){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.classList.remove(className);
        }
    };

    append(strHtml){
        jQuery.append(this._string, strHtml);
        return this;
    }

    static append(selector, strHtml){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.insertAdjacentHTML('afterbegin', strHtml);
        }        
    };

    remove(){
        jQuery.remove(this._string);
        return this;
    }

    static remove(selector){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.remove();
        }        
    };

    text(){
        return jQuery.text(this._string);
    }

    static text(node){
        let element = document.querySelector(node);
        return element.innerText;
    };

    attr(attributeName, value){
        return jQuery.attr(this._string, attributeName, value);
    };

    //Get the value of an attribute for the first element in the set of matched elements
    //value != null set one or more attributes for every matched element.
    static attr(selector, attributeName, value){
        let element = document.querySelector(selector);
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
        let result = [];
        if (!selector)
            return element.childNodes;

        for (let child of element.childNodes){            
            if (child.nodeType == 1 && child.matches(selector)){
                result.push(child);
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
        
        while (element.firstChild){
            let child = element.firstChild;
            child.remove();    
        }        
    };

    css(property){
        jQuery.css(this._string, property);
        return this;
    }

    static css(node, property){
        let element = document.querySelector(node);
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
        element.addEventListener('click', callback);
    };

    foreach(callback){
        this.foreach(this._string, callback);
        return this;
    }

    static foreach(selector, callback){
        let elements = document.querySelectorAll(selector);
        for(let element of elements){
            callback.call(null, element);
        }
    }

    toggle(){
        jQuery.toggle(this._string);
        return this;
    }

    static toggle(selector){
        let elements = document.querySelectorAll(selector);
        for(let element of elements){
            element.style.display = "none";
        }
    }
}

jQuery.addClass('body', 'katya');
jQuery.removeClass('body', 'katya');
jQuery.remove('li');
jQuery.append('ul', '<li>SMILE one</li>');

let bodyQuery = new jQuery('body');

console.log(bodyQuery.addClass('kay').append('<li>SMILE two</li>').text());
jQuery.addClass('li', 'ha');

console.log(jQuery.css('body', 'background-color'));
jQuery.css('li', "background-color:blue");


console.log(jQuery.children(".demo-container", 'ul'));
console.log(jQuery.attr(".demo-box", 'something'));
jQuery.click('body', function() {
    alert("addEventListener"); 
  });