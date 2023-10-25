import dxForm from "devextreme/ui/form";


export  const getFromData = (form:dxForm)=>{
	return form.option("formData");

}