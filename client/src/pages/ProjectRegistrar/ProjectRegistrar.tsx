import {Button, Form} from "devextreme-react";
import {GroupItem, Label, SimpleItem} from "devextreme-react/form";
import {DxHtmlEditorDefault} from "../../config/dxDefault/dxHtmlEditor.default.ts";
import {useTranslation} from "react-i18next";


export const ProjectRegistrar = ()=>{
	const {t} = useTranslation()
	return (
		<>
			<Form>

				<GroupItem caption={t("caption.projectRegistrar")}>
					<SimpleItem dataField={"Name"}>
						<Label text={t("label.project.Name")}/>
					</SimpleItem>
					<SimpleItem dataField={"Description"} editorType={"dxHtmlEditor"} editorOptions={{
						height: 200,
						...DxHtmlEditorDefault
					}}>
						<Label text={t("label.project.Description")}/>

					</SimpleItem>
					<SimpleItem dataField={"Members"}  editorType={"dxTagBox"}>
						<Label text={t("label.project.Members")}/>

					</SimpleItem>
				</GroupItem>
			</Form>
			<Button text={t("button.save")} icon={"save"} type={"success"}/>
		</>

	)
}