// Constructor function
Validator = (options) => {
    
    let getParent = (element, selector) => {
        while (element.parentElement) {
            if (element.parentElement.matches(selector)) {
                return element.parentElement;
            }
            element = element.parentElement;
        }
    }

    let selectorRules = {};

    let validate = (inputElement, rule) => {
        let errorElement = getParent(inputElement, options.formGroupSelector).querySelector(options.errorSelector);
        // let errorElement = inputElement.parentElement.querySelector(options.errorSelector);
        let errorMessage = rule.test(inputElement.value);

        // Lấy ra các rules của selector
        let rules = selectorRules[rule.selector];

        // Lặp qua từng rule và kiểm tra
        for (let i = 0; i < rules.length; i++) {
            switch (inputElement.type) {
                case 'radio':
                case 'checkbox':
                    errorMessage = rules[i](formElement.querySelector(rule.selector) + ":checked");
                    break;
                default:
                    errorMessage = rules[i](inputElement.value);
            }
            // errorMessage = rules[i](inputElement.value);
            if (errorMessage) break;
        }

        if (errorMessage) {
            errorElement.innerText = errorMessage;
            getParent(inputElement, options.formGroupSelector).classList.add("invalid");
        } else {
            errorElement.innerText = "";
            getParent(inputElement, options.formGroupSelector).classList.remove("invalid");
        }
        return !errorMessage;
    }

    // Lấy element của form cần validate
    let formElement = document.querySelector(options.form);
    // console.log(options.rules);

    if (formElement) {
        formElement.onsubmit = (e) => {
            e.preventDefault();

            let isFormValid = true;

            options.rules.forEach((rule) => {
                let inputElement = formElement.querySelector(rule.selector);
                let isValid = validate(inputElement, rule);
                if (!isValid) {
                    isFormValid = false;
                }
            });

            if (isFormValid) {
                // Trường hợp submit với javascript
                if (typeof options.onSubmit === 'function') {

                    let enableInputs = formElement.querySelectorAll("[name]");
                    let formValues = Array.from(enableInputs).reduce((values, input) => {
                        values[input.name] = input.value
                        return values;
                    }, {});

                    options.onSubmit(formValues);
                } else {
                    formElement.submit();
                }
            }
        }

        // Xử lý lặp qua mỗi rule
        options.rules.forEach((rule) => {
            // Lưu lại các rules cho mỗi input
            if (Array.isArray(selectorRules[rule.selector])) {
                selectorRules[rule.selector].push(rule.test);
            } else {
                selectorRules[rule.selector] = [rule.test];
            }

            let inputElements = formElement.querySelectorAll(rule.selector);

            Array.from(inputElements).forEach((inputElement) => {
                if (inputElement) {
                    
                    // Xử lý trường hợp blur khỏi input
                    inputElement.onblur = () => {
                        validate(inputElement, rule);
                    }
                    
                    // Xử lý mỗi khi người dùng nhập vào input
                    inputElement.oninput = () => {
                        let errorElement = getParent(inputElement, options.formGroupSelector).querySelector('.form-message');
                        errorElement.innerText = "";
                        getParent(inputElement, options.formGroupSelector).classList.remove("invalid");
                    }
                }
            });

        });
    }
};

// Định nghĩa các rules
Validator.isRequired = (selector) => {
    return {
        selector: selector,
        test: (value) => { return value && value.trim() != "" ? undefined : "Không được để trống" }
    }
};

Validator.isEmail = (selector) => {
    return {
        selector: selector,
        test: (value) => {
            let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : "Email không hợp lệ";
        }
    }
};

Validator.minLength = (selector, minLength) => {
    return {
        selector: selector,
        test: (value) => { return value.length >= minLength ? undefined : `Vui lòng nhập tối thiểu ${minLength} ký tự` }
    }
};


Validator.isConfirmed = (selector, getConfirmValue, message) => {
    return {
        selector: selector,
        test: (value) => { return value === getConfirmValue() ? undefined : message || "Giá trị nhập vào không chính xác" }
    }
}