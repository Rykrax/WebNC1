
// Constructor function
Validator = (options) => {
    let formElement = document.querySelector(options.form);
    // if (formElement) {
    //     options.rules.forEach((rule) => {
    //         let inputElement = formElement.querySelector(rule.selector);
    //         if (inputElement) {
    //             inputElement.onblur = () => {
    //                 console.log("onblur");
    //             }
    //         }
    //     });
    // }
    if (formElement) {
        console.log(formElement);
    }
};

// Định nghĩa các rules
Validator.isRequired = () => {

};

Validator.isEmail = () => {

};

Validator.isPassword = () => {

};
