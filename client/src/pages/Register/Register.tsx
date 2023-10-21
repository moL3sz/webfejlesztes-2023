import {Form} from "devextreme-react";
import {ButtonItem, EmailRule, GroupItem, Label, RequiredRule, SimpleItem} from "devextreme-react/form";
import {useRegister} from "./hooks/useRegister.ts";


export const Register = ()=>{

	const {t, formRef, register} = useRegister();
	return (
		<div className={"flex flex-col justify-center items-center"}>
			<h3>{t("title.register")}</h3>
			<Form width={600} ref={formRef}>
				<GroupItem colCount={2}>
					<SimpleItem dataField={"FirstName"}>
						<Label text={t("label.register.FirstName")}/>
						<RequiredRule/>
					</SimpleItem>
					<SimpleItem dataField={"LastName"}>
						<Label text={t("label.register.LastName")}/>
						<RequiredRule/>

					</SimpleItem>
				</GroupItem>
				<SimpleItem dataField={"Username"}>
					<Label text={t("label.register.Username")}/>
					<RequiredRule/>

				</SimpleItem>
				<SimpleItem dataField={"Email"} editorType={"dxTextBox"} editorOptions={{
					mode:"email"
				}}>
					<Label text={t("label.register.Email")}/>
					<RequiredRule/>
					<EmailRule/>
				</SimpleItem>
				<SimpleItem dataField={"Password"} editorType={"dxTextBox"} editorOptions={{
					mode:"password"
				}}>
					<Label text={t("label.register.Password")}/>
					<RequiredRule/>

				</SimpleItem>
				<SimpleItem dataField={"Password"} editorType={"dxTextBox"} editorOptions={{
					mode:"password"
				}}>
					<Label text={t("label.register.PasswordConfirm")}/>
					<RequiredRule/>

				</SimpleItem>

				<ButtonItem buttonOptions={{
					type: "default",
					width: "100%",
					icon: "login",
					text:t("button.register"),
					onClick: register
				}}/>
			</Form>
		</div>

	)
}