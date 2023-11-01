import {useUserProfile} from "./hooks/useUserProfile.ts";
import {FileUploader, Form} from "devextreme-react";
import {ButtonItem, GroupItem, Label, SimpleItem} from "devextreme-react/form";
import {getFromData} from "../../utils/form.util.ts";
import {PendingProjects} from "./components/PendingProjects.tsx";
import {useTranslation} from "react-i18next";


export const UserProfile = () => {


	const {userProfileFormRef} = useUserProfile();

	const {t} = useTranslation()

	return (
		<div className={"flex half flex-col space-x-0 xl:flex-row xl:space-x-10 space-y-10 xl:space-y-0"}>
			<Form ref={userProfileFormRef} labelMode={"floating"}>
				<GroupItem caption={t("caption.basicData")} cssClass={"card mb-5"}>
					<SimpleItem editorOptions={{stylingMode: "outlined"}} render={(data) => {

						const formData = data.component.option("formData");
						const {FirstName, LastName,Id} = formData;
						return <div className={"flex items-center space-x-10"}>

							<img src={"https://img.freepik.com/premium-vector/man-avatar-profile-picture-vector-illustration_268834-541.jpg"} className={"w-40 profile-pic"}/>
							<div>
								<h5>{FirstName} {LastName}</h5>
								<div className={"text-base text-gray-400"}>Id: {Id}</div>
								<FileUploader stylingMode={"outlined"} selectButtonText={t("button.uploadPhoto")}/>

							</div>
						</div>
					}}/>


					<GroupItem colCount={2} >
						<SimpleItem dataField={"FirstName"}  editorOptions={{stylingMode: "outlined"}}>
							<Label text={t("label.profile.FirstName")}/>
						</SimpleItem>
						<SimpleItem dataField={"LastName"} editorOptions={{stylingMode: "outlined"}} >
							<Label text={t("label.profile.LastName")}/>
						</SimpleItem>


					</GroupItem>
				</GroupItem>
				<GroupItem caption={t("caption.contact")} cssClass={"card"}>
					<SimpleItem render={(e)=>{
						const {Email, PhoneNumber} = getFromData(e.component);
						return (
							<div className={"flex items-center space-x-10"}>
								<div className={"text-4xl text-red-700 contact-icon font-bold p-4 w-16 h-16 flex items-center"}>
									<span>@</span>
								</div>
								<div className={"flex flex-col space-y-1"}>
									<p className={"text-base"}>{PhoneNumber ? PhoneNumber : "Nincs telefonszám"}</p>
									<p className={"text-sm text-gray-400"}>{Email}<i className={"ms-2 dx-icon dx-icon-copy text-sm cursor-pointer active:text-red-700"}></i></p>
								</div>
							</div>
						)
					}}/>
					<GroupItem colCount={2}>
						<SimpleItem dataField={"PhoneNumber"} editorOptions={{stylingMode: "outlined"}}>
							<Label text={t("label.profile.PhoneNumber")}/>

						</SimpleItem>
						<SimpleItem dataField={"Email"} editorOptions={{stylingMode: "outlined", readOnly:true}}>
							<Label text={t("label.profile.Email")}/>

						</SimpleItem>
					</GroupItem>

				</GroupItem>

				<ButtonItem buttonOptions={{text:"Mentés", icon:"save",type:"default"}}></ButtonItem>




			</Form>

			<div className={""}>
				<h4>{t("title.pendingProjects")}</h4>
				<PendingProjects/>
			</div>

		</div>
	)
}