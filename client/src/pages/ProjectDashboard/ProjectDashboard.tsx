import {Item as ToolbarItem, Toolbar} from "devextreme-react/toolbar";
import {useProjectDashboard} from "./hooks/useProjectDashboard.ts";
import {TicketList} from "./components/TicketList/TicketList.tsx";
import {Form, Popup} from "devextreme-react";
import {ToolbarItem as PopupToolbarItem} from "devextreme-react/popup"
import {GroupItem, RequiredRule, SimpleItem} from "devextreme-react/form";
import {DxHtmlEditorDefault} from "../../config/dxDefault/dxHtmlEditor.default.ts";


export const ProjectDashboard = () => {

	const {project, addTicketPopupRef, ticketFormRef,t} = useProjectDashboard()

	return (
		<div className={"h-[100vh]"}>
			<Toolbar className={"border-b-[1px] border-b-zinc-600 mb-4"}>
				<ToolbarItem location={"before"} render={() => (
					<h5>{project?.Title}</h5>
				)}/>
				<ToolbarItem widget={"dxButton"} location={"after"} options={{
					text: "Emberek meghívása", //TODO: Resouce
					type: "normal",
					stylingMode: "filled",
					icon: "message"
				}}/>
				<ToolbarItem widget={"dxButton"} location={"after"} options={{
					text: "Feladat",//TODO: Resouce
					stylingMode: "filled",
					icon: "plus",
					type: "default",
					onClick: () => {
						addTicketPopupRef.current?.instance.show();
					}
				}}/>
			</Toolbar>
			<div className={"project-container flex flex-col"}>

				<TicketList/>

			</div>

			<Popup width={"50%"}
				   hideOnOutsideClick={true}
				   title={t("popup.title.addTicket")}
				   ref={addTicketPopupRef} onHiding={(e) => e.component.hide()}>
				<Form ref={ticketFormRef}>
					<SimpleItem dataField={"Title"}>
						<RequiredRule/>
					</SimpleItem>
					<GroupItem colCount={2}>
						<SimpleItem dataField={"CategoryId"} editorType={"dxSelectBox"}>
							<RequiredRule/>
						</SimpleItem>
						<SimpleItem dataField={"StatusId"} editorType={"dxSelectBox"}>
							<RequiredRule/>
						</SimpleItem>
						<SimpleItem dataField={"PriorityId"} editorType={"dxSelectBox"}>
							<RequiredRule/>
						</SimpleItem>
					</GroupItem>


					<SimpleItem dataField={"Description"} editorType={"dxHtmlEditor"} editorOptions={{
						height: 200,
						...DxHtmlEditorDefault
					}}>
					</SimpleItem>

				</Form>
				<PopupToolbarItem toolbar={"bottom"} widget={"dxButton"} location={"after"} options={{
					icon:"save",
					text:"Létrehozás",
					type: "success",
					stylingMode: "filled"
				}}/>
				<PopupToolbarItem toolbar={"bottom"} widget={"dxButton"} location={"after"} options={{
					icon:"remove",
					text:"Mégse",
					type: "danger",
					stylingMode: "outlined"
				}}/>
			</Popup>
		</div>
	)

}