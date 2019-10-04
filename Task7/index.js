const jQuery = {

    addClass : function(selector, className){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.classList.add(className);
        }
    },

    removeClass : function(selector, className){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.classList.remove(className);
        }
    },

    append: function(selector, strHtml){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.insertAdjacentHTML('afterbegin', strHtml);
        }        
    },

    remove: function(selector){
        let elements = document.querySelectorAll(selector);
        for(let element of elements ) {
            element.remove();
        }        
    },

    text: function(node){
        let element = document.querySelector(node);
        return element.innerText;
    },

    //Get the value of an attribute for the first element in the set of matched elements
    //value != null set one or more attributes for every matched element.
    attr: function(selector, attributeName, value){
        let element = document.querySelector(selector);
        if (value){
            element.setAtttibute(attributeName, value);
        }
        else{
            return element.getAttribute(attributeName);            
        }
    },

    //Get the children of each element in the set of matched elements, optionally filtered by a selector.
    children: function (node, selector){
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
    },

    //Remove all child nodes of the set of matched elements from the DOM.
    empty: function(node){
        let element = document.querySelector(node);
        
        while (element.firstChild){
            let child = element.firstChild;
            child.remove();    
        }        
    },

    css: function(node, property){
        let element = document.querySelector(node);
        return window.getComputedStyle(element).getPropertyValue(property);
    },

    click: function(node, callback){
        let element = document.querySelector(node);
        element.addEventListener('click', callback);
    }
}

jQuery.addClass('body', 'katya');
jQuery.removeClass('body', 'katya');

jQuery.remove('li');
jQuery.append('ul', '<li>SMILE one</li>');

//jQuery.empty('ul');
console.log(jQuery.css('body', 'background-color'));


console.log(jQuery.children(".demo-container", 'ul'));
console.log(jQuery.attr(".demo-box", 'something'));
jQuery.click('body', function() {
    alert("addEventListener"); 
  });