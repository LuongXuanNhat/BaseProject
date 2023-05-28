/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	config.toolbarGroups = [
		{ name: 'styles', groups: ['styles'] },
		{ name: 'paragraph', groups: ['align', 'list', 'indent', 'blocks', 'bidi', 'paragraph'] },
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'insert', groups: ['insert'] },
		{ name: 'colors', groups: ['colors'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
		{ name: 'document', groups: ['document', 'doctools', 'mode'] },
		{ name: 'forms', groups: ['forms'] },
		{ name: 'links', groups: ['links'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		'/',
		'/',
		{ name: 'tools', groups: ['tools'] },
		{ name: 'others', groups: ['others'] },
		{ name: 'about', groups: ['about'] }
	];

	config.removeButtons = 'Save,NewPage,ExportPdf,Print,Source,Templates,Replace,PasteFromWord,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Indent,Outdent,CreateDiv,BidiRtl,BidiLtr,Language,Anchor,PasteText,About,ShowBlocks,Maximize,Styles,Format,Font,SpecialChar,PageBreak,Iframe,Smiley,HorizontalRule,Superscript,Subscript,Copy,Cut,Paste,RemoveFormat,CopyFormatting,Unlink,Link';
};
