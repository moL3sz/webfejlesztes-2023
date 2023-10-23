


export const stripHTML =(content: string)=>{
	return content.replace(/<[^>]*>?/gm, '');
}