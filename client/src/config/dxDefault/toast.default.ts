import notify from "devextreme/ui/notify";


export const defaultToastConfig =
	{

		height: 45,
		width: 450,
		minWidth: 200,
		displayTime: 3500,
		animation: {
			show: {
				type: 'fade', duration: 400, from: 0, to: 1,
			},
			hide: {type: 'fade', duration: 200, from: 1, to: 0},
		},

	}
export const defaultToastStack = {
	position: "bottom left",
	direction: "up-push"
} as any;

export const defaultNotify = (message: string, type: "success" | "error" | "info" | "warning")=>{
	notify({message, type, ...defaultToastConfig}, defaultToastStack)
}