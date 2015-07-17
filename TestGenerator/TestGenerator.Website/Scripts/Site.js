function addParameter() {
    var template = $('#parameterTemplate').clone();
    template.removeClass("hidden");
    template.removeAttr("id");
    $('#parameterContainer').append(template);
}

function removeParameter() {
    $('#parameterContainer').children().last().remove();
}

function getParams() {
    var params = {},
        i,
        key,
        param,
        paramInputs = $('.parameter:not(.hidden)');

    for (i = 0; i < paramInputs.length; i++) {
        param = $(paramInputs[i]);
        key = param.children('.type').val().toString();
        params[key] = param.children('.instance').val();
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

    $.post("/TestGen/Home/GetTestFile",
        model,
        function (response) {
            $('#output').html('<pre><code class="language-csharp line-numbers">'
                + response + '</code></pre>');
            Prism.highlightAll();
        });
}

$(document).ready(function () {
    $('#addParam').click(addParameter);
    $('#removeParam').click(removeParameter);
    $('#generate').click(generateTests);
});