import {useUserProfile} from "./hooks/useUserProfile.ts";
import {FileUploader, Form} from "devextreme-react";
import {ButtonItem, GroupItem, Label, SimpleItem} from "devextreme-react/form";
import {getFromData} from "../../utils/form.util.ts";
import {PendingProjects} from "./components/PendingProjects.tsx";


export const UserProfile = () => {


	const {userProfileFormRef} = useUserProfile();


	return (
		<div className={"flex half flex-col space-x-0 xl:flex-row xl:space-x-10 space-y-10 xl:space-y-0"}>
			<Form className={""} ref={userProfileFormRef} labelMode={"floating"}>
				<GroupItem caption={"Alap adatok"} cssClass={"card mb-5"}>
					<SimpleItem editorOptions={{stylingMode: "outlined"}} render={(data) => {
						const {FirstName, LastName, Id} = getFromData(data.component);
						return <div className={"flex items-center space-x-10"}>

							<img src={"https://img.freepik.com/premium-vector/man-avatar-profile-picture-vector-illustration_268834-541.jpg"} className={"w-40 profile-pic"}/>
							<div>
								<h5>{FirstName} {LastName}</h5>
								<div className={"text-base text-gray-400"}>ID: {Id}</div>
								<FileUploader stylingMode={"outlined"} selectButtonText={"Képfeltöltés"}/>

							</div>
						</div>
					}}/>


					<GroupItem colCount={2} >
						<SimpleItem dataField={"FirstName"}  editorOptions={{stylingMode: "outlined"}}>
							<Label text={"Vezetéknév"}/>
						</SimpleItem>
						<SimpleItem dataField={"LastName"} editorOptions={{stylingMode: "outlined"}} >
							<Label text={"Keresztnév"}/>
						</SimpleItem>


					</GroupItem>
				</GroupItem>
				<GroupItem caption={"Elérhetőségek"} cssClass={"card"}>
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
							<Label text={"Telefonszám"}/>

						</SimpleItem>
						<SimpleItem dataField={"Email"} editorOptions={{stylingMode: "outlined", readOnly:true}}>
							<Label text={"Email cím"}/>

						</SimpleItem>
					</GroupItem>
					<SimpleItem dataField={"A"} editorOptions={{stylingMode: "outlined"}} editorType={"dxSelectBox"}>
						<Label text={"Státusz"}/>
					</SimpleItem>
				</GroupItem>

				<ButtonItem buttonOptions={{text:"Mentés", icon:"save",type:"default"}}></ButtonItem>




			</Form>

			<div className={""}>
				<h4>Elfogadásra váró projektek</h4>
				<PendingProjects/>
			</div>

		</div>
	)
}