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
    $.post("/TestGen/GetNullParamTests",
       null,
       function (response) {
           alert(response);
       });
}

$(document).ready(function () {
    $(addParam).click(addParameter);
    $(removeParam).click(removeParameter);
    $(generate).click(generateTests);
});