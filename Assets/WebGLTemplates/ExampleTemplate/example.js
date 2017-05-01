gameInstance.Module.onRuntimeInitialized = function() {
	message_received_from_js = gameInstance.Module.cwrap('message_received_from_js',null,['string']);
};

class ExampleStructure {
	
  constructor(x, y, some_string, string_list) {
    this.x = x;
    this.y = y;
	this.some_string = some_string;
	this.string_list = string_list;
  }
}

document.onkeydown = function (e) {
  e = e || window.event;
  switch (e.which || e.keyCode) {
        case 13 :
			var example_strucutre = new ExampleStructure(12, 1, "some string 123", ['dog','cat','cow']);
			message_received_from_js(JSON.stringify(example_strucutre));
		break;
  }
}
