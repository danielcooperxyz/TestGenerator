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

$(document).ready(function () {
    $(addParam).click(addParameter);
    $(removeParam).click(removeParameter);
});