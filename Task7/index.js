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

    append: function(selector, node){
        let elements = document.querySelectorAll(selector);
        console.log(elements);
        for(let element of elements ) {
            console.log(element.nodeName)
            element.append(node);
        }
    },

    remove: function(selector, node){
        //node.remove;
    },

    text: function(node){
        //node.childNodes
        //return text
    },

    attr: function(selector, attributeName, value){
        //Get the value of an attribute for the first element in the set of matched elements
        //value != null set one or more attributes for every matched element.
    },

    children: function (selector){
        //Get the children of each element in the set of matched elements, optionally filtered by a selector.
    },

    empty: function(){
        //Remove all child nodes of the set of matched elements from the DOM.
    },

    css: function(selector, property){
        //Get value of property
    },

    click: function(selector, callback){
        //Bind an event handler to the "click" JavaScript event,
    }
}

jQuery.addClass('body', 'katya');
jQuery.removeClass('body', 'katya');
jQuery.append('body', '<h2> Hello, its me </h2>');
console.log(document.body.classList);