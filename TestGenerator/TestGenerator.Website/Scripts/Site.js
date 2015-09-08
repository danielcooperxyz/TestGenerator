function getParams() {
    var params = {},
        i,
        key,
        param,
        paramInputs = $('.parameter:not(.hidden)');

    for (i = 0; i < paramInputs.length; i++) {
        param = $(paramInputs[i]);
        key = param.children('.type').val().toString();
        if (key) {
            params[key] = param.children('.instance').val();
        }
    }

    return params;
}

function generateTests() {
    var parameters = getParams(),
        model = {
            'TypeOfClassToTest': $('#TypeOfClassToTest').val(),
            'ClassToTest': $('#ClassToTest').val(),
            'ClassParameters': parameters
        };

    $.post($('#test-gen-url').val(), model)
        .done(function (response) {
            $('#output').html('<pre><code class="language-csharp line-numbers">'
                + response + '</code></pre>');
            Prism.highlightAll();
        })
        .fail(function (err) {
            var dummy = document.createElement('iframe');
            dummy.src = "data:text/html;charset=utf-8," + escape(err.responseText);
            dummy.width = "100%";
            dummy.height = "500px";
            $('#output').html(dummy);
        });
}

function submit(event) {
    if (event.keyCode === 13) {
        generateTests();
    }
}

function addParameter() {
    var template = $('#parameterTemplate').clone();
    template.removeClass("hidden");
    template.removeAttr("id");
    $('#parameterContainer').append(template);

    $('input[type="text"]').off('keyup');
    $('input[type="text"]').on('keyup', submit);
}

function removeParameter() {
    $('#parameterContainer').children().last().remove();
}

$(document).ready(function () {
    $('#addParam').click(addParameter);
    $('#removeParam').click(removeParameter);
    $('#generate').click(generateTests);

    $('input[type="text"]').keyup(submit);
});