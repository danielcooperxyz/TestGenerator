function addParameter()
{
    template = $(parameterTemplate).clone();
    template.removeClass("hidden");
    template.removeAttr("id");
    $(parameterContainer).append(template);
}

function removeParameter()
{
    $(parameterContainer).children().last().remove();
}

function getParams()
{
    var params = {};

    var paramInputs = $('.parameter:not(.hidden)');

    for (var i = 0; i < paramInputs.length; i++)
    {
        var param = $(paramInputs[i]);
        params[param.children('.type').val().toString()] = param.children('.instance').val();
    }

    return params;
}

function generateTests()
{
    var parameters = getParams();

    var model = {
        'TypeOfClassToTest': $(TypeOfClassToTest).val(),
        'ClassToTest': $(ClassToTest).val(),
        'ClassParameters': parameters
    }

    $.post("/TestGen/Home/GetNullParamTests",
       model,
    function (response) {
        $(output).html('<code class="language-csharp line-numbers">' + response + '</code>');
        Prism.highlightAll();
    });
}

$(document).ready(function () {
    $(addParam).click(addParameter);
    $(removeParam).click(removeParameter);
    $(generate).click(generateTests);
});