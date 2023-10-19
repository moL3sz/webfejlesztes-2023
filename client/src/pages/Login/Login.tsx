import {Form} from "devextreme-react";
import {useTranslation} from "react-i18next";
import {ButtonItem, Label, SimpleItem} from "devextreme-react/form";


export const Login = ()=>{

	const {t} = useTranslation();

	return (
		<div className={"flex flex-col justify-center items-center"}>
			<h3>{t("title.login")}</h3>
			<Form width={400}>
				<SimpleItem dataField={"Username"}>
					<Label text={t("label.login.Username")}/>

				</SimpleItem>
				<SimpleItem dataField={"Password"} editorType={"dxTextBox"} editorOptions={{
					mode:"password"
				}}>
					<Label text={t("label.login.Password")}/>

				</SimpleItem>

				<ButtonItem buttonOptions={{
					type: "default",
					width: "100%",
					icon: "login",
					text:t("button.login")
				}}/>
			</Form>
		</div>

	)
}