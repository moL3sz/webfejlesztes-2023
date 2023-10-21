import {Form} from "devextreme-react";
import {ButtonItem, EmailRule, Label, SimpleItem} from "devextreme-react/form";
import {useLogin} from "./hooks/useLogin.ts";


export const Login = () => {

	const {t, formRef, login} = useLogin()

	return (
		<div className={"flex flex-col justify-center items-center"}>
			<h3>{t("title.login")}</h3>
			<Form width={400} ref={formRef}>
				<SimpleItem dataField={"Email"}>
					<Label text={t("label.login.Email")}/>
					<EmailRule/>
				</SimpleItem>
				<SimpleItem dataField={"Password"} editorType={"dxTextBox"} editorOptions={{
					mode: "password"
				}}>
					<Label text={t("label.login.Password")}/>

				</SimpleItem>

				<ButtonItem buttonOptions={{
					type: "default",
					width: "100%",
					icon: "login",
					text: t("button.login"),
					onClick: login
				}}/>
			</Form>
		</div>

	)
}