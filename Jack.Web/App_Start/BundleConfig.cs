using Jack.Library;
using System.Web.Optimization;

namespace Jack.Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {

            #region CSS Bundles
            RegisterCssBundle(ref bundles);
            #endregion

            #region javascript Bundles
            RegisterJsBundle(ref bundles);
            #endregion

            #region Toastr
            RegisterToastrBundle(ref bundles);
            #endregion

            #region Main Bundles
            RegisterMainBundle(ref bundles);
            #endregion

            #region TipoItem Bundles
            RegisterTipoItemBundle(ref bundles);
            #endregion

            #region Familia Bundles
            RegisterFamiliaBundle(ref bundles);
            #endregion

            #region Criança Bundles
            RegisterCriancaBundle(ref bundles);
            #endregion

            #region Presença Bundles
            RegisterPresencaBundle(ref bundles);
            #endregion

            #region Representante Bundles
            RegisterRepresentanteBundle(ref bundles);
            #endregion

            #region Colaborador Bundles
            RegisterColaboradorBundle(ref bundles);
            #endregion

            #region Sacolas Bundles
            RegisterSacolasBundle(ref bundles);
            #endregion

            #region Print Sacolas Bundles
            RegisterPrintSacolasBundle(ref bundles);
            #endregion

            #region Vestimentas Bundles
            RegisterVestimentasBundle(ref bundles);
            #endregion

            #region Kit Bundles
            RegisterKitBundle(ref bundles);
            #endregion

            #region Status Bundles
            RegisterStatusBundle(ref bundles);
            #endregion

            #region Nivel Bundles
            RegisterNivelBundle(ref bundles);
            #endregion

            #region Tipo Parentesco Bundles
            RegisterTipoParentescoBundle(ref bundles);
            #endregion

            #region Feriado Bundles
            RegisterFeriadoBundle(ref bundles);
            #endregion

            #region Reuniao Bundles
            RegisterReuniaoBundle(ref bundles);
            #endregion

            #region Reuniao Bundles
            RegisterProcessarBundle(ref bundles);
            #endregion

            #region QrCode Bundles
            RegisterQrCodeBundle(ref bundles);
            #endregion
        }

        private static void RegisterCssBundle(ref BundleCollection bundles)
        {
            // CSS style (bootstrap/inspinia)
            var cssInspinia = new StyleBundle("~/Content/css");
            cssInspinia.Include("~/Content/bootstrap.min.css",
                                "~/Content/animate.css",
                                "~/Content/main.css",
                                "~/Content/style.css");
            cssInspinia.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssInspinia);

            var cssClear = new StyleBundle("~/Content/cssClear");
            cssClear.Include("~/Content/bootstrap.min.css",
                "~/Content/animate.css",
                "~/Content/main.css");
            cssClear.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssClear);

            // Font Awesome icons
            var cssAwesome = new StyleBundle("~/font-awesome/css");
            cssAwesome.Include("~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform());
            cssAwesome.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssAwesome);

            // jQueryUI CSS
            var cssJQueryUi = new StyleBundle("~/Scripts/plugins/jquery-ui/jqueryuiStyles");
            cssJQueryUi.Include("~/Scripts/plugins/jquery-ui/jquery-ui.css");
            cssJQueryUi.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssJQueryUi);

            // Morriss chart css styles
            var cssMorris = new StyleBundle("~/plugins/morrisStyles");
            cssMorris.Include("~/Content/plugins/morris/morris-0.4.3.min.css");
            cssMorris.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssMorris);

            // blue imp
            var cssBlueImp = new StyleBundle("~/Content/plugins/blueimp/css/");
            cssBlueImp.Include("~/Content/plugins/blueimp/css/blueimp-gallery.min.css");
            cssBlueImp.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssBlueImp);

            // dataTables css styles
            var cssDataTables = new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles");
            cssDataTables.Include("~/Content/plugins/dataTables/datatables.min.css");
            cssDataTables.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssDataTables);

            // jqGrid styles
            var cssJqGrid = new StyleBundle("~/Content/plugins/jqGrid/jqGridStyles");
            cssJqGrid.Include("~/Content/plugins/jqGrid/ui.jqgrid.css");
            cssJqGrid.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssJqGrid);

            // codeEditor styles
            var cssCodeEditorStyles = new StyleBundle("~/plugins/codeEditorStyles");
            cssCodeEditorStyles.Include("~/Content/plugins/codemirror/codemirror.css",
                                        "~/Content/plugins/codemirror/ambiance.css");
            cssCodeEditorStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssCodeEditorStyles);

            // fullCalendar styles
            var cssFullCalendar = new StyleBundle("~/plugins/fullCalendarStyles");
            cssFullCalendar.Include("~/Content/plugins/fullcalendar/fullcalendar.css");
            cssFullCalendar.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssFullCalendar);

            // ionRange styles
            var cssIonRangeStyles = new StyleBundle("~/Content/plugins/ionRangeSlider/ionRangeStyles");
            cssIonRangeStyles.Include("~/Content/plugins/ionRangeSlider/ion.rangeSlider.css",
                                      "~/Content/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css");
            cssIonRangeStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssIonRangeStyles);

            // dataPicker styles
            var cssDataPicker = new StyleBundle("~/plugins/dataPickerStyles");
            cssDataPicker.Include("~/Content/plugins/datapicker/datepicker3.css");
            cssDataPicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssDataPicker);

            // nouiSlider styles
            var cssNouiSliderStyles = new StyleBundle("~/plugins/nouiSliderStyles");
            cssNouiSliderStyles.Include("~/Content/plugins/nouslider/jquery.nouislider.css");
            cssNouiSliderStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssNouiSliderStyles);

            // jasnyBootstrap styles
            var cssJasnyBootstrap = new StyleBundle("~/plugins/jasnyBootstrapStyles");
            cssJasnyBootstrap.Include("~/Content/plugins/jasny/jasny-bootstrap.min.css");
            cssJasnyBootstrap.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssJasnyBootstrap);

            // switchery styles
            var cssSwitcheryStyles = new StyleBundle("~/plugins/switcheryStyles");
            cssSwitcheryStyles.Include("~/Content/plugins/switchery/switchery.css");
            cssSwitcheryStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSwitcheryStyles);

            // chosen styles
            var cssChosenStyles = new StyleBundle("~/Content/plugins/chosen/chosenStyles");
            cssChosenStyles.Include("~/Content/plugins/chosen/chosen.css");
            cssChosenStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssChosenStyles);

            // wizardSteps styles
            var cssWizardStepsStyles = new StyleBundle("~/plugins/wizardStepsStyles");
            cssWizardStepsStyles.Include("~/Content/plugins/steps/jquery.steps.css");
            cssWizardStepsStyles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssWizardStepsStyles);

            // dropZone styles
            var cssDropZone = new StyleBundle("~/Content/plugins/dropzone/dropZoneStyles");
            cssDropZone.Include("~/Content/plugins/dropzone/basic.css",
                                "~/Content/plugins/dropzone/dropzone.css");
            cssDropZone.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssDropZone);

            // summernote styles
            var cssSummerNote = new StyleBundle("~/plugins/summernoteStyles");
            cssSummerNote.Include("~/Content/plugins/summernote/summernote.css",
                                  "~/Content/plugins/summernote/summernote-bs3.css");
            cssSummerNote.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSummerNote);

            // color picker styles
            var cssCollorPicker = new StyleBundle("~/Content/plugins/colorpicker/colorpickerStyles");
            cssCollorPicker.Include("~/Content/plugins/colorpicker/bootstrap-colorpicker.min.css");
            cssCollorPicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssCollorPicker);

            // image cropper styles
            var cssImageCrop = new StyleBundle("~/plugins/imagecropperStyles");
            cssImageCrop.Include("~/Content/plugins/cropper/cropper.min.css");
            cssImageCrop.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssImageCrop);

            // jsTree styles
            var cssJsTree = new StyleBundle("~/Content/plugins/jsTree");
            cssJsTree.Include("~/Content/plugins/jsTree/style.css");
            cssJsTree.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssJsTree);

            // Chartist
            var cssChartist = new StyleBundle("~/plugins/chartistStyles");
            cssChartist.Include("~/Content/plugins/chartist/chartist.min.css");
            cssChartist.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssChartist);

            // iCheck css styles
            var cssiCheck = new StyleBundle("~/Content/plugins/iCheck/iCheckStyles");
            cssiCheck.Include("~/Content/plugins/iCheck/custom.css");
            cssiCheck.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssiCheck);

            // Awesome bootstrap checkbox
            var cssAwesomeChk = new StyleBundle("~/plugins/awesomeCheckboxStyles");
            cssAwesomeChk.Include("~/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css");
            cssAwesomeChk.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssAwesomeChk);

            // Clockpicker styles
            var cssClockpicker = new StyleBundle("~/plugins/clockpickerStyles");
            cssClockpicker.Include("~/Content/plugins/clockpicker/clockpicker.css");
            cssClockpicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssClockpicker);

            // Date range picker Styless
            var cssDateRanger = new StyleBundle("~/plugins/dateRangeStyles");
            cssDateRanger.Include("~/Content/plugins/daterangepicker/daterangepicker-bs3.css");
            cssDateRanger.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssDateRanger);

            // Footable Styless
            var cssFootable = new StyleBundle("~/plugins/footableStyles");
            cssFootable.Include("~/Content/plugins/footable/footable.core.css", new CssRewriteUrlTransform());
            cssFootable.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssFootable);

            // Select2 Styless
            var cssSelect2 = new StyleBundle("~/plugins/Select2");
            cssSelect2.Include("~/Content/plugins/select2/select2.min.css");
            cssSelect2.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSelect2);

            // Slick carousel Styless
            var cssSlick = new StyleBundle("~/plugins/slickStyles");
            cssSlick.Include("~/Content/plugins/slick/slick.css", new CssRewriteUrlTransform());
            cssSlick.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSlick);

            // Slick carousel theme Styless
            var cssSlickTheme = new StyleBundle("~/plugins/slickThemeStyles");
            cssSlickTheme.Include("~/Content/plugins/slick/slick-theme.css", new CssRewriteUrlTransform());
            cssSlickTheme.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSlickTheme);

            // Ladda buttons Styless
            var cssLadda = new StyleBundle("~/plugins/laddaStyles");
            cssLadda.Include("~/Content/plugins/ladda/ladda-themeless.min.css");
            cssLadda.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssLadda);

            // Touch Spin Styless
            var cssTouch = new StyleBundle("~/plugins/touchSpinStyles");
            cssTouch.Include("~/Content/plugins/touchspin/jquery.bootstrap-touchspin.min.css");
            cssTouch.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssTouch);

            // Tour Styless
            var cssTour = new StyleBundle("~/plugins/tourStyles");
            cssTour.Include("~/Content/plugins/bootstrapTour/bootstrap-tour.min.css");
            cssBlueImp.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssBlueImp);

            // c3 Styless
            var cssC3 = new StyleBundle("~/plugins/c3Styles");
            cssC3.Include(
                      "~/Content/plugins/c3/c3.min.css");
            cssC3.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssC3);

            // Markdown Styless
            var cssMarkdown = new StyleBundle("~/plugins/markdownStyles");
            cssMarkdown.Include("~/Content/plugins/bootstrap-markdown/bootstrap-markdown.min.css");
            cssMarkdown.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssMarkdown);

            // Sweet alert Styless
            var cssSweet = new StyleBundle("~/plugins/sweetAlertStyles");
            cssSweet.Include("~/Content/plugins/sweetalert/sweetalert.css");
            cssSweet.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssSweet);

            // c3 Styless
            var cssC3Styles = new StyleBundle("~/plugins/c3Styles");
            cssC3Styles.Include("~/Content/plugins/c3/c3.min.css");
            cssC3Styles.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssC3Styles);

            // TypeAhead
            //var cssTypeAhead = new StyleBundle("~/plugins/TypeAhead");
            //cssTypeAhead.Include("~/Content/plugins/c3/c3.min.css");
            //cssTypeAhead.Orderer = new AsIsBundleOrderer();
            //bundles.Add(cssTypeAhead);

        }

        private static void RegisterJsBundle(ref BundleCollection bundles)
        {

            // jQuery
            var jssjQuery = new ScriptBundle("~/bundles/jquery");
            jssjQuery.Include("~/Scripts/jquery-2.1.1.min.js");
            jssjQuery.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssjQuery);

            // jQueryUI
            var jssjQueryUi = new ScriptBundle("~/bundles/jqueryui");
            jssjQueryUi.Include("~/Scripts/plugins/jquery-ui/jquery-ui.min.js");
            jssjQueryUi.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssjQueryUi);

            // Bootstrap
            var jssBootstrap = new ScriptBundle("~/bundles/bootstrap");
            jssBootstrap.Include("~/Scripts/bootstrap.min.js");
            jssBootstrap.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssBootstrap);

            // Inspinia script
            var jssInspinia = new ScriptBundle("~/bundles/inspinia");
            jssInspinia.Include("~/Scripts/plugins/metisMenu/metisMenu.min.js",
                                 "~/Scripts/plugins/pace/pace.min.js",
                                 "~/Scripts/app/inspinia.js");
            jssInspinia.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssInspinia);

            // Inspinia script - Skin Config      
            var jssSkinConfig = new ScriptBundle("~/bundles/skinConfig");
            jssSkinConfig.Include("~/Scripts/app/skin.config.min.js");
            jssSkinConfig.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSkinConfig);

            // bootbox
            var jssBootBox = new ScriptBundle("~/bundles/bootbox");
            jssBootBox.Include("~/Scripts/bootbox.min.js");
            jssBootBox.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssBootBox);

            // bootbox
            var jssMask = new ScriptBundle("~/bundles/jquery-mask-plugin");
            jssMask.Include("~/Scripts/plugins/jquery-mask-plugin/jquery.mask.min.js");
            jssMask.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssMask);

            // SlimScroll
            var jssSlimScroll = new ScriptBundle("~/bundles/slimScroll");
            jssSlimScroll.Include("~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js");
            jssSlimScroll.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSlimScroll);

            // Peity
            var jssPeity = new ScriptBundle("~/plugins/peity");
            jssPeity.Include("~/Scripts/plugins/peity/jquery.peity.min.js");
            jssPeity.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssPeity);

            // Video Responsible
            var jssVideoResponsible = new ScriptBundle("~/plugins/videoResponsible");
            jssVideoResponsible.Include("~/Scripts/plugins/video/responsible-video.js");
            jssVideoResponsible.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssVideoResponsible);

            // Lightbox gallery
            var jssLightboxGallery = new ScriptBundle("~/Content/plugins/lightboxGallery");
            jssLightboxGallery.Include("~/Scripts/plugins/blueimp/jquery.blueimp-gallery.min.js");
            jssLightboxGallery.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssLightboxGallery);

            // Sparkline
            var jssSparkline = new ScriptBundle("~/Content/plugins/sparkline");
            jssSparkline.Include("~/Scripts/plugins/sparkline/jquery.sparkline.min.js");
            jssSparkline.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSparkline);

            // Morriss chart css styles
            var jssMorriss = new ScriptBundle("~/Content/plugins/morris");
            jssMorriss.Include("~/Scripts/plugins/morris/raphael-2.1.0.min.js",
                               "~/Scripts/plugins/morris/morris.js");
            jssMorriss.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssMorriss);

            // Flot chart
            var jssFlot = new ScriptBundle("~/plugins/flot");
            jssFlot.Include("~/Scripts/plugins/flot/jquery.flot.js",
                            "~/Scripts/plugins/flot/jquery.flot.tooltip.min.js",
                            "~/Scripts/plugins/flot/jquery.flot.resize.js",
                            "~/Scripts/plugins/flot/jquery.flot.pie.js",
                            "~/Scripts/plugins/flot/jquery.flot.time.js",
                            "~/Scripts/plugins/flot/jquery.flot.spline.js");
            jssFlot.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssFlot);

            // Rickshaw chart
            var jssRickSaw = new ScriptBundle("~/plugins/rickshaw");
            jssRickSaw.Include("~/Scripts/plugins/rickshaw/vendor/d3.v3.js",
                      "~/Scripts/plugins/rickshaw/rickshaw.min.js");
            jssRickSaw.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssRickSaw);

            // ChartJS chart
            var jssChartJs = new ScriptBundle("~/plugins/chartJs");
            jssChartJs.Include("~/Scripts/plugins/chartjs/Chart.min.js");
            jssChartJs.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssChartJs);

            // iCheck
            var jssiCheck = new ScriptBundle("~/plugins/iCheck");
            jssiCheck.Include("~/Scripts/plugins/iCheck/icheck.min.js");
            jssiCheck.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssiCheck);

            // DataTables
            var jssDataTables = new ScriptBundle("~/plugins/dataTables");
            jssDataTables.Include("~/Scripts/plugins/dataTables/datatables.min.js");
            jssDataTables.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDataTables);

            // jeditable
            var jssJeditable = new ScriptBundle("~/plugins/jeditable");
            jssJeditable.Include("~/Scripts/plugins/jeditable/jquery.jeditable.js");
            jssJeditable.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssJeditable);

            // jqGrid
            var jssjqGrid = new ScriptBundle("~/plugins/jqGrid");
            jssjqGrid.Include("~/Scripts/plugins/jqGrid/i18n/grid.locale-pt-br.js",
                              "~/Scripts/plugins/jqGrid/jquery.jqGrid.min.js");
            jssjqGrid.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssjqGrid);

            // Tour Spin
            var jssTour = new ScriptBundle("~/plugins/tour").Include(
                      "~/Scripts/plugins/bootstrapTour/bootstrap-tour.min.js");
            jssTour.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTour);

            // codeEditor
            var jssCodeEditor = new ScriptBundle("~/plugins/codeEditor");
            jssCodeEditor.Include("~/Scripts/plugins/codemirror/codemirror.js",
                                  "~/Scripts/plugins/codemirror/mode/javascript/javascript.js");
            jssCodeEditor.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssCodeEditor);

            // nestable
            var jssNestable = new ScriptBundle("~/plugins/Nestable");
            jssNestable.Include("~/Scripts/plugins/nestable/jquery.nestable.js");
            jssNestable.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssNestable);

            // validate
            var jssValidate = new ScriptBundle("~/plugins/validate");
            jssValidate.Include("~/Scripts/plugins/validate/jquery.validate.min.js");
            jssValidate.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssValidate);

            // fullCalendar
            var jssFullCalendar = new ScriptBundle("~/plugins/fullCalendar");
            jssFullCalendar.Include("~/Scripts/plugins/fullcalendar/moment.min.js",
                                    "~/Scripts/plugins/fullcalendar/fullcalendar.min.js");
            jssFullCalendar.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssFullCalendar);

            // Moment
            var jssMoment = new ScriptBundle("~/plugins/Moment");
            jssMoment.Include("~/Scripts/plugins/fullcalendar/moment.min.js");
            jssMoment.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssMoment);

            // vectorMap
            var jssVectorMap = new ScriptBundle("~/plugins/vectorMap");
            jssVectorMap.Include("~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                                 "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js");
            jssVectorMap.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssVectorMap);

            // ionRange 
            var jssIonRange = new ScriptBundle("~/plugins/ionRange");
            jssIonRange.Include("~/Scripts/plugins/ionRangeSlider/ion.rangeSlider.min.js");
            jssIonRange.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssIonRange);

            // dataPicker 
            var jssDataPicker = new ScriptBundle("~/plugins/dataPicker");
            jssDataPicker.Include("~/Scripts/plugins/datapicker/bootstrap-datepicker.js");
            jssDataPicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDataPicker);

            // nouiSlider 
            var jssNouiSlider = new ScriptBundle("~/plugins/nouiSlider");
            jssNouiSlider.Include("~/Scripts/plugins/nouslider/jquery.nouislider.min.js");
            jssNouiSlider.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssNouiSlider);

            // jasnyBootstrap 
            var jssJasnyBootstrap = new ScriptBundle("~/plugins/jasnyBootstrap");
            jssJasnyBootstrap.Include("~/Scripts/plugins/jasny/jasny-bootstrap.min.js");
            jssJasnyBootstrap.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssJasnyBootstrap);

            // switchery 
            var jssSwitchery = new ScriptBundle("~/plugins/switchery");
            jssSwitchery.Include("~/Scripts/plugins/switchery/switchery.js");
            jssSwitchery.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSwitchery);

            // chosen 
            var jssChosen = new ScriptBundle("~/plugins/chosen");
            jssChosen.Include(
                      "~/Scripts/plugins/chosen/chosen.jquery.js");
            jssChosen.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssChosen);

            // knob 
            var jssKnob = new ScriptBundle("~/plugins/knob");
            jssKnob.Include("~/Scripts/plugins/jsKnob/jquery.knob.js");
            jssKnob.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssKnob);

            // wizardSteps 
            var jssWizardSteps = new ScriptBundle("~/plugins/wizardSteps");
            jssWizardSteps.Include("~/Scripts/plugins/staps/jquery.steps.min.js");
            jssWizardSteps.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssWizardSteps);

            // dropZone 
            var jssDropZone = new ScriptBundle("~/plugins/dropZone");
            jssDropZone.Include("~/Scripts/plugins/dropzone/dropzone.js");
            jssDropZone.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDropZone);

            // summernote 
            var jssSummerNote = new ScriptBundle("~/plugins/summernote");
            jssSummerNote.Include("~/Scripts/plugins/summernote/summernote.min.js");
            jssSummerNote.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSummerNote);

            // color picker
            var jssColorPicker = new ScriptBundle("~/plugins/colorpicker");
            jssColorPicker.Include("~/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.js");
            jssColorPicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssColorPicker);

            // image cropper
            var jssImageCropper = new ScriptBundle("~/plugins/imagecropper");
            jssImageCropper.Include("~/Scripts/plugins/cropper/cropper.min.js");
            jssImageCropper.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssImageCropper);

            // jsTree
            var jssTree = new ScriptBundle("~/plugins/jsTree");
            jssTree.Include("~/Scripts/plugins/jsTree/jstree.min.js");
            jssTree.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTree);

            // Diff
            var jssDiff = new ScriptBundle("~/plugins/diff");
            jssDiff.Include("~/Scripts/plugins/diff_match_patch/javascript/diff_match_patch.js",
                               "~/Scripts/plugins/preetyTextDiff/jquery.pretty-text-diff.min.js");
            jssDiff.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDiff);

            // Idle timer
            var jssIdleTimer = new ScriptBundle("~/plugins/idletimer");
            jssIdleTimer.Include("~/Scripts/plugins/idle-timer/idle-timer.min.js");
            jssIdleTimer.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssIdleTimer);

            // Tinycon
            var jssTinyIcon = new ScriptBundle("~/plugins/tinycon");
            jssTinyIcon.Include("~/Scripts/plugins/tinycon/tinycon.min.js");
            jssTinyIcon.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTinyIcon);

            // chartist styles
            var jssChartList = new ScriptBundle("~/plugins/chartist");
            jssChartList.Include("~/Scripts/plugins/chartist/chartist.min.js");
            jssChartList.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssChartList);

            // Clockpicker
            var jssClockPicker = new ScriptBundle("~/plugins/clockpicker");
            jssClockPicker.Include("~/Scripts/plugins/clockpicker/clockpicker.js");
            jssClockPicker.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssClockPicker);

            // Date range picker
            var jssDateRange = new ScriptBundle("~/plugins/dateRange");
            jssDateRange.Include("~/Scripts/plugins/fullcalendar/moment.min.js",
                               "~/Scripts/plugins/daterangepicker/daterangepicker.js");
            jssDateRange.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDateRange);

            // Sweet alert
            var jssSweetAlert = new ScriptBundle("~/plugins/sweetAlert");
            jssSweetAlert.Include("~/Scripts/plugins/sweetalert/sweetalert.min.js");
            jssSweetAlert.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSweetAlert);

            // Footable alert
            var jssFootable = new ScriptBundle("~/plugins/footable");
            jssFootable.Include("~/Scripts/plugins/footable/footable.all.min.js");
            jssFootable.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssFootable);

            // Select2
            var jssSelect2 = new ScriptBundle("~/plugins/select2");
            jssSelect2.Include("~/Scripts/plugins/select2/select2.full.min.js");
            jssSelect2.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSelect2);

            // Masonry
            var jssMasonry = new ScriptBundle("~/plugins/masonry");
            jssMasonry.Include("~/Scripts/plugins/masonary/masonry.pkgd.min.js");
            jssMasonry.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssMasonry);

            // Slick carousel
            var jssSlick = new ScriptBundle("~/plugins/slick");
            jssSlick.Include("~/Scripts/plugins/slick/slick.min.js");
            jssSlick.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSlick);

            // Ladda buttons
            var jssLadda = new ScriptBundle("~/plugins/ladda");
            jssLadda.Include("~/Scripts/plugins/ladda/spin.min.js",
                      "~/Scripts/plugins/ladda/ladda.min.js",
                      "~/Scripts/plugins/ladda/ladda.jquery.min.js");
            jssLadda.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssLadda);

            // Dotdotdot buttons
            var jssDotdotdot = new ScriptBundle("~/plugins/truncate");
            jssDotdotdot.Include("~/Scripts/plugins/dotdotdot/jquery.dotdotdot.min.js");
            jssDotdotdot.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssDotdotdot);

            // Touch Spin
            var jssTouchSpin = new ScriptBundle("~/plugins/touchSpin");
            jssTouchSpin.Include("~/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js");
            jssTouchSpin.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTouchSpin);

            // i18next Spin
            var jssI18Next = new ScriptBundle("~/plugins/i18next");
            jssI18Next.Include("~/Scripts/plugins/i18next/i18next.min.js");
            jssI18Next.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssI18Next);

            // Clipboard Spin
            var jssClipboard = new ScriptBundle("~/plugins/clipboard");
            jssClipboard.Include("~/Scripts/plugins/clipboard/clipboard.min.js");
            jssClipboard.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssClipboard);

            // c3 Spin
            var jssC3 = new ScriptBundle("~/plugins/c3");
            jssC3.Include("~/Scripts/plugins/c3/c3.min.js");
            jssC3.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssC3);

            // d3 Spin
            var jssD3 = new ScriptBundle("~/plugins/d3");
            jssD3.Include("~/Scripts/plugins/d3/d3.min.js");
            jssD3.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssD3);

            // Markdown Spin
            var jssMarkdown = new ScriptBundle("~/plugins/markdown");
            jssMarkdown.Include("~/Scripts/plugins/bootstrap-markdown/bootstrap-markdown.js",
                      "~/Scripts/plugins/bootstrap-markdown/markdown.js");
            jssMarkdown.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssMarkdown);

        }

        private static void RegisterToastrBundle(ref BundleCollection bundles)
        {
            // toastr notification styles
            var cssToaStr = new StyleBundle("~/plugins/toastr");
            cssToaStr.Include("~/Content/plugins/toastr/toastr.min.css");
            bundles.Add(cssToaStr);

            // toastr notification 
            var jssToastr = new ScriptBundle("~/bundles/toastr");
            jssToastr.Include("~/Scripts/plugins/toastr/toastr.min.js");
            jssToastr.Include("~/Scripts/toastr-configuracao.js");
            jssToastr.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssToastr);

        }

        private static void RegisterMainBundle(ref BundleCollection bundles)
        {

            var jssjQuery = new ScriptBundle("~/script/main");
            jssjQuery.Include("~/Scripts/main.js");
            jssjQuery.Include("~/Scripts/util/ajax.js");
            jssjQuery.Include("~/Scripts/util/mensagens.js");
            jssjQuery.Include("~/Scripts/util/util.js");
            jssjQuery.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssjQuery);

        }

        private static void RegisterTipoItemBundle(ref BundleCollection bundles)
        {

            var jssCaracteristica = new ScriptBundle("~/script/TipoItem/main");
            jssCaracteristica.Include("~/Scripts/TipoItem/main.js");
            jssCaracteristica.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssCaracteristica);

        }

        private static void RegisterFamiliaBundle(ref BundleCollection bundles)
        {

            var jssAluno = new ScriptBundle("~/script/familia/main");
            jssAluno.Include("~/Scripts/familia/main.js");
            jssAluno.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssAluno);


        }

        private static void RegisterCriancaBundle(ref BundleCollection bundles)
        {

            var jssCrianca = new ScriptBundle("~/script/Crianca/main");
            jssCrianca.Include("~/Scripts/Crianca/main.js");
            jssCrianca.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssCrianca);

            var jssCriancaAcerto = new ScriptBundle("~/script/Crianca/acerto/Dados");
            jssCriancaAcerto.Include("~/Scripts/Crianca/acertoDados.js");
            jssCriancaAcerto.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssCriancaAcerto);


        }

        private static void RegisterPresencaBundle(ref BundleCollection bundles)
        {

            var jssPresenca = new ScriptBundle("~/script/Presenca/lista");
            jssPresenca.Include("~/Scripts/Presenca/lista.js");
            jssPresenca.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssPresenca);

            jssPresenca = new ScriptBundle("~/script/Presenca/main");
            jssPresenca.Include("~/Scripts/Presenca/main.js");
            jssPresenca.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssPresenca);

            jssPresenca = new ScriptBundle("~/script/Presenca/Reunioes");
            jssPresenca.Include("~/Scripts/Presenca/PresencaReunioes.js");
            jssPresenca.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssPresenca);
        }

        private static void RegisterRepresentanteBundle(ref BundleCollection bundles)
        {

            var jssResponsavel = new ScriptBundle("~/script/Representante/main");
            jssResponsavel.Include("~/Scripts/Representante/main.js");
            jssResponsavel.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssResponsavel);

        }

        private static void RegisterColaboradorBundle(ref BundleCollection bundles)
        {

            var jssColaborador = new ScriptBundle("~/script/Colaborador/main");
            jssColaborador.Include("~/Scripts/Colaborador/main.js");
            jssColaborador.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssColaborador);

            jssColaborador = new ScriptBundle("~/script/ColaboradorCrianca/main");
            jssColaborador.Include("~/Scripts/Colaborador/ColaboradorCrianca.js");
            jssColaborador.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssColaborador);

            jssColaborador = new ScriptBundle("~/script/ColaboradorCrianca/Add");
            jssColaborador.Include("~/Scripts/Colaborador/ColaboradorCriancaAdd.js");
            jssColaborador.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssColaborador);

            jssColaborador = new ScriptBundle("~/script/ColaboradorCrianca/Add/Lista");
            jssColaborador.Include("~/Scripts/Colaborador/ColaboradorCriancaAddLista.js");
            jssColaborador.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssColaborador);
        }

        private static void RegisterSacolasBundle(ref BundleCollection bundles)
        {

            var jssSacolas = new ScriptBundle("~/script/Sacolas/main");
            jssSacolas.Include("~/Scripts/Sacolas/main.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            jssSacolas = new ScriptBundle("~/script/Sacolas/AdicionarCriancas");
            jssSacolas.Include("~/Scripts/Sacolas/AdicionarCrianca.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            jssSacolas = new ScriptBundle("~/script/Sacolas/Pesquisa");
            jssSacolas.Include("~/Scripts/Sacolas/SacolasPesquisa.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

        }

        private static void RegisterPrintSacolasBundle(ref BundleCollection bundles)
        {


            var jssjMain = new ScriptBundle("~/script/main/Sacolas");
            jssjMain.Include("~/Scripts/util/ajax.js");
            jssjMain.Include("~/Scripts/util/mensagens.js");
            jssjMain.Include("~/Scripts/util/util.js");
            jssjMain.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssjMain);

            var jssSacolas = new ScriptBundle("~/script/Sacolas/QrCode");
            jssSacolas.Include("~/Scripts/Sacolas/QrCode.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            jssSacolas = new ScriptBundle("~/script/Sacolas/Modelo");
            jssSacolas.Include("~/Scripts/Sacolas/modelo.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            jssSacolas = new ScriptBundle("~/script/Sacolas/Print");
            jssSacolas.Include("~/Scripts/Sacolas/print.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            jssSacolas = new ScriptBundle("~/script/Sacolas/Gerar");
            jssSacolas.Include("~/Scripts/Sacolas/Gerar.js");
            jssSacolas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssSacolas);

            // CSS Print 
            var cssLoad = new StyleBundle("~/Content/Sacola/Print");
            cssLoad.Include("~/Content/printsacola.css", "~/Content/main.css");
            cssLoad.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssLoad);
        }

        private static void RegisterKitBundle(ref BundleCollection bundles)
        {

            var jssKit = new ScriptBundle("~/script/Kit/main");
            jssKit.Include("~/Scripts/Kit/main.js");
            jssKit.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssKit);

            jssKit = new ScriptBundle("~/script/KitItem/main");
            jssKit.Include("~/Scripts/KitItem/main.js");
            jssKit.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssKit);

        }

        private static void RegisterVestimentasBundle(ref BundleCollection bundles)
        {

            var jssVestimentas = new ScriptBundle("~/script/Calcado/main");
            jssVestimentas.Include("~/Scripts/Calcado/main.js");
            jssVestimentas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssVestimentas);

            jssVestimentas = new ScriptBundle("~/script/Roupa/main");
            jssVestimentas.Include("~/Scripts/Roupa/main.js");
            jssVestimentas.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssVestimentas);

        }

        private static void RegisterStatusBundle(ref BundleCollection bundles)
        {

            var jssStatus = new ScriptBundle("~/script/Status/crianca");
            jssStatus.Include("~/Scripts/StatusCrianca/main.js");
            jssStatus.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssStatus);

            jssStatus = new ScriptBundle("~/script/Status/familia");
            jssStatus.Include("~/Scripts/StatusFamilia/main.js");
            jssStatus.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssStatus);

        }

        private static void RegisterNivelBundle(ref BundleCollection bundles)
        {

            var jssNivel = new ScriptBundle("~/script/Nivel/main");
            jssNivel.Include("~/Scripts/Nivel/main.js");
            jssNivel.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssNivel);

        }

        private static void RegisterTipoParentescoBundle(ref BundleCollection bundles)
        {

            var jssTipoParentesco = new ScriptBundle("~/script/TipoParentesco/main");
            jssTipoParentesco.Include("~/Scripts/TipoParentesco/main.js");
            jssTipoParentesco.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTipoParentesco);

        }

        private static void RegisterFeriadoBundle(ref BundleCollection bundles)
        {

            var jssTipoParentesco = new ScriptBundle("~/script/Feriado/main");
            jssTipoParentesco.Include("~/Scripts/Feriado/main.js");
            jssTipoParentesco.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTipoParentesco);

        }

        private static void RegisterReuniaoBundle(ref BundleCollection bundles)
        {

            var jssTipoParentesco = new ScriptBundle("~/script/Reuniao/main");
            jssTipoParentesco.Include("~/Scripts/Reuniao/main.js");
            jssTipoParentesco.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTipoParentesco);

        }

        private static void RegisterProcessarBundle(ref BundleCollection bundles)
        {

            var jssTipoParentesco = new ScriptBundle("~/script/Processa/main");
            jssTipoParentesco.Include("~/Scripts/Processa/main.js");
            jssTipoParentesco.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTipoParentesco);

        }
        private static void RegisterQrCodeBundle(ref BundleCollection bundles)
        {

            var jssTipoParentesco = new ScriptBundle("~/script/qrcode");
            jssTipoParentesco.Include("~/Scripts/util/qrcode.js");
            jssTipoParentesco.Orderer = new AsIsBundleOrderer();
            bundles.Add(jssTipoParentesco);

        }

    }
}
