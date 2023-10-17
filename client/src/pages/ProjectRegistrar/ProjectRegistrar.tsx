import {Form} from "devextreme-react";
import {GroupItem, SimpleItem} from "devextreme-react/form";
import {DxHtmlEditorDefault} from "../../config/dxDefault/dxHtmlEditor.default.ts";


export const ProjectRegistrar = ()=>{
	return (
		<Form>

			<GroupItem caption={"Projekt regisztrálása"}>
				<SimpleItem dataField={"Name"}/>
				<SimpleItem dataField={"Description"} editorType={"dxHtmlEditor"} editorOptions={{
					height: 200,
					...DxHtmlEditorDefault
				}}/>
			</GroupItem>
		</Form>
	)
}