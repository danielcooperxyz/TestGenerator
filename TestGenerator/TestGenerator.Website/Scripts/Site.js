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

function generateTests()
{
    $.post("/TestGen/Home/GetNullParamTests",
       null,
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