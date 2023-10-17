
export const DxHtmlEditorDefault = {
	toolbar: {
		items: [
			'undo', 'redo', 'separator',
			{
				name: 'header',
				acceptedValues: [false, 1, 2, 3, 4, 5],
				options: { inputAttr: { 'aria-label': 'Header' } },
			}, 'separator',
			'bold', 'italic', 'strike', 'underline', 'separator',
			'alignLeft', 'alignCenter', 'alignRight', 'alignJustify', 'separator',
			'orderedList', 'bulletList',
		],
	},
}