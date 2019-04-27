

function alert_success(message)
{
    $("#div_alert").html("");
  
    var html = "<div class=\"alert alert-success alert-dismissible\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button> <h4><i class=\"icon fa fa-check\"></i> Alert!</h4> " + message + " </div > ";
    $("#div_alert").html(html);
    $("#div_alert").hide();
    $("#div_alert").show().delay(2000).hide(300);
   

}


function alert_danger(message) {
    $("#div_alert").html("");
    var html = "<div class=\"alert alert-danger alert-dismissible\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button> <h4><i class=\"icon fa fa-check\"></i> Alert!</h4> " + message + " </div > ";
    $("#div_alert").html(html);
    $("#div_alert").hide();
    $("#div_alert").show().delay(3000).hide(300);

}

function alert_info(message) {
    $("#div_alert").html("");
    var html = "<div class=\"alert alert-info alert-dismissible\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button> <h4><i class=\"icon fa fa-check\"></i> Alert!</h4> " + message + " </div > ";
    $("#div_alert").html(html);
    $("#div_alert").hide();
    $("#div_alert").show().delay(2000).hide(300);

}

function alert_warning(message) {
    $("#div_alert").html("");
    var html = "<div class=\"alert alert-warning alert-dismissible\">  <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button> <h4><i class=\"icon fa fa-check\"></i> Alert!</h4> " + message + " </div > ";
    $("#div_alert").html(html);
    $("#div_alert").hide();
    $("#div_alert").show().delay(2000).hide(300);

}