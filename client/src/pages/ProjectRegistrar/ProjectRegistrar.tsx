import {Button, Form} from "devextreme-react";
import {GroupItem, Label, RequiredRule, SimpleItem} from "devextreme-react/form";
import {DxHtmlEditorDefault} from "../../config/dxDefault/dxHtmlEditor.default.ts";
import {useProjectRegister} from "./hooks/useProjectRegister.ts";


export const ProjectRegistrar = ()=>{
	const {t, createProject, formRef} = useProjectRegister()
	return (
		<>
			<Form ref={formRef}>
				<GroupItem caption={t("caption.projectRegistrar")}>
					<GroupItem colCount={2}>
						<SimpleItem dataField={"Title"}>
							<RequiredRule/>
							<Label text={t("label.project.Name")}/>
						</SimpleItem>
						<SimpleItem dataField={"Code"}>
							<Label text={t("label.project.Code")}/>
						</SimpleItem>
						<SimpleItem dataField={"Range"}  editorType={"dxDateRangeBox"} editorOptions={{
							showClearButton: true,
							labelMode:"floating",
							startDateLabel: t("label.project.StartDate"),
							endDateLabel: t("label.project.EndDate")
						}}>
							<RequiredRule/>
						</SimpleItem>
					</GroupItem>

					<SimpleItem dataField={"Description"} editorType={"dxHtmlEditor"} editorOptions={{
						height: 200,
						...DxHtmlEditorDefault
					}}>
						<Label text={t("label.project.Description")}/>
					</SimpleItem>
				</GroupItem>
			</Form>
			<Button text={t("button.save")} icon={"save"} type={"success"} onClick={createProject}/>
		</>

	)
}