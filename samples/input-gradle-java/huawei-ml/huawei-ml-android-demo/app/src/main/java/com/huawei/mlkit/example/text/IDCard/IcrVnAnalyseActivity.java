/*
 * Copyright 2020. Huawei Technologies Co., Ltd. All rights reserved.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

package com.huawei.mlkit.example.text.IDCard;

import android.Manifest;
import android.content.ContentValues;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.res.Configuration;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.MediaStore;
import android.provider.Settings;
import android.util.Log;
import android.view.Display;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import com.huawei.hmf.tasks.OnFailureListener;
import com.huawei.hmf.tasks.OnSuccessListener;
import com.huawei.hmf.tasks.Task;
import com.huawei.hms.mlplugin.card.icr.vn.MLVnIcrCapture;
import com.huawei.hms.mlplugin.card.icr.vn.MLVnIcrCaptureConfig;
import com.huawei.hms.mlplugin.card.icr.vn.MLVnIcrCaptureFactory;
import com.huawei.hms.mlplugin.card.icr.vn.MLVnIcrCaptureResult;
import com.huawei.hms.mlsdk.card.MLCardAnalyzerFactory;
import com.huawei.hms.mlsdk.card.icr.MLIcrAnalyzer;
import com.huawei.hms.mlsdk.card.icr.MLIcrAnalyzerSetting;
import com.huawei.hms.mlsdk.card.icr.MLIdCard;
import com.huawei.hms.mlsdk.common.MLFrame;
import com.huawei.mlkit.example.R;

import java.io.IOException;

/**
 * It provides the identification function of the second-generation ID card of Chinese residents,
 * and recognizes formatted text information from the images with ID card information.
 * ID Card identification provides on-cloud and on-device API.
 *
 * @since 2020-12-16
 */
public class IcrVnAnalyseActivity extends AppCompatActivity implements View.OnClickListener {
    private static final String TAG = IcrVnAnalyseActivity.class.getSimpleName();
    private static final int CAMERA_PERMISSION_CODE = 1;
    private TextView mTextView;

    private boolean isFront;

    private ImageView previewImageFront;

    private ImageView previewImageBack;

    private MLIcrAnalyzer localAnalyzer;


    private Bitmap cardFront;

    private String cardResultFront = "";

    private String cardResultBack = "";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.setContentView(R.layout.activity_image_icr_analyse);
        this.mTextView = this.findViewById(R.id.text_result);
        this.previewImageFront = this.findViewById(R.id.IDCard_image_front);
        this.previewImageBack = this.findViewById(R.id.IDCard_image_back);
        this.previewImageBack.setVisibility(View.GONE);
        this.previewImageFront.setScaleType(ImageView.ScaleType.FIT_XY);
        this.findViewById(R.id.detect).setOnClickListener(this);
        this.previewImageFront.setOnClickListener(this);
        if (Build.VERSION.SDK_INT>=Build.VERSION_CODES.M &&!(ActivityCompat.checkSelfPermission(this, Manifest.permission.CAMERA) == PackageManager.PERMISSION_GRANTED)) {
            this.requestPermission();
        }

    }

    private void requestPermission() {
        if (ContextCompat.checkSelfPermission(this,
                Manifest.permission.READ_CONTACTS)
                != PackageManager.PERMISSION_GRANTED) {

            if (ActivityCompat.shouldShowRequestPermissionRationale(this,
                    Manifest.permission.READ_CONTACTS)) {

                ActivityCompat.requestPermissions(this,
                        new String[]{Manifest.permission.READ_CONTACTS,Manifest.permission.READ_EXTERNAL_STORAGE,Manifest.permission.WRITE_EXTERNAL_STORAGE},
                        CAMERA_PERMISSION_CODE);

            } else {
                Log.i(TAG,"requestPermissions");
                // No explanation needed, we can request the permission.
                ActivityCompat.requestPermissions(this,
                        new String[]{Manifest.permission.CAMERA,Manifest.permission.READ_EXTERNAL_STORAGE,Manifest.permission.WRITE_EXTERNAL_STORAGE},
                        CAMERA_PERMISSION_CODE);

            }
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
        switch (requestCode) {
            case CAMERA_PERMISSION_CODE: {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.length > 0
                        && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                } else {
                    if (!ActivityCompat.shouldShowRequestPermissionRationale(this, permissions[0])) {
                        showWaringDialog();
                    } else {
                        Toast.makeText(this, R.string.toast, Toast.LENGTH_SHORT).show();
                        finish();
                    }
                }
                return;
            }

        }
    }


    private void showWaringDialog() {
        AlertDialog.Builder dialog = new AlertDialog.Builder(this);
        dialog.setMessage(R.string.Information_permission)
                .setPositiveButton(R.string.go_authorization, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        //Guide the user to the setting page for manual authorization.
                        Intent intent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
                        Uri uri = Uri.fromParts("package", getApplicationContext().getPackageName(), null);
                        intent.setData(uri);
                        startActivity(intent);
                    }
                })
                .setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        //Instruct the user to perform manual authorization. The permission request fails.
                        finish();
                    }
                }).setOnCancelListener(dialogInterface);
        dialog.setCancelable(false);
        dialog.show();
    }

    static DialogInterface.OnCancelListener dialogInterface =  new DialogInterface.OnCancelListener() {
        @Override
        public void onCancel(DialogInterface dialog) {
            //Instruct the user to perform manual authorization. The permission request fails.
        }
    };

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.IDCard_image_front:
                this.isFront = true;
                this.mTextView.setText("");
                // Use plugins for camera stream detection.
                this.startCaptureActivity(this.idCallBack);
                break;
            case R.id.detect:
                this.isFront = true;
                this.mTextView.setText("");
                // Use plugins for static image detection.
                this.startTakePhotoActivity();
                // Use SDK for on-device static image detection.
                //   this.localAnalyzer();
                break;
            default:
                break;
        }
    }

    private void localAnalyzer() {
        if (this.cardFront == null) {
            this.mTextView.setText("Please take the front photo of IDCard.");
            return;
        }
        // Use customized parameter settings for device-based recognition.
        MLIcrAnalyzerSetting setting = new MLIcrAnalyzerSetting.Factory()
                .setSideType(MLIcrAnalyzerSetting.FRONT)
                .create();
        this.localAnalyzer = MLCardAnalyzerFactory.getInstance().getIcrAnalyzer(setting);
        // Create an MLFrame by using the bitmap. Recommended image size: large than 512*512.
        Bitmap bitmap = this.cardFront;
        MLFrame frame = MLFrame.fromBitmap(bitmap);
        Task<MLIdCard> task = this.localAnalyzer.asyncAnalyseFrame(frame);
        task.addOnSuccessListener(new OnSuccessListener<MLIdCard>() {
            @Override
            public void onSuccess(MLIdCard mlIdCard) {
                // Recognition success.
                IcrVnAnalyseActivity.this.displaySuccess(mlIdCard, true);
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(Exception e) {
                // Recognition failure.
                IcrVnAnalyseActivity.this.displayFailure(e.getMessage());
            }
        });
    }

    private void displaySuccess(MLIdCard mlIdCard, boolean isFront) {
        StringBuilder resultBuilder = new StringBuilder();
        if (isFront) {
            resultBuilder.append("Name：" + mlIdCard.getName() + "\r\n");
            resultBuilder.append("Sex：" + mlIdCard.getSex()+ "\r\n");
            resultBuilder.append("Birthday：" + mlIdCard.getBirthday() + "\r\n");
            resultBuilder.append("IDNum: " + mlIdCard.getIdNum() + "\r\n");
        }
        this.mTextView.setText(resultBuilder.toString());
    }


    private Uri mImageUri;
    private static final int REQUEST_IMAGE_CAPTURE = 1001;
    private Bitmap imageBitmap;
    private void startTakePhotoActivity() {
        mImageUri = null;
        Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        if (takePictureIntent.resolveActivity(getPackageManager()) != null) {
            ContentValues values = new ContentValues();
            values.put(MediaStore.Images.Media.TITLE, "New Picture");
            values.put(MediaStore.Images.Media.DESCRIPTION, "From Camera");
            mImageUri = getContentResolver().insert(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, values);
            takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT, mImageUri);
            startActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
        }
    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent intent) {
        super.onActivityResult(requestCode, resultCode, intent);
        Log.i(TAG, "onActivityResult requestCode " + requestCode + ", resultCode " + resultCode);
        if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == RESULT_OK) {
            if (intent != null) {
                this.mImageUri = intent.getData();
            }
            startCaptureImageActivity(idCallBack);
        }
    }


    private String formatIdCardResult(MLVnIcrCaptureResult idCardResult, boolean isFront) {
        StringBuilder resultBuilder = new StringBuilder();
        if (isFront) {
            resultBuilder.append("Name：" + idCardResult.getName() + "\r\n");
            resultBuilder.append("Sex：" + idCardResult.getSex()+ "\r\n");
            resultBuilder.append("Birthday：" + idCardResult.getBirthday() + "\r\n");
            resultBuilder.append("IDNum: " + idCardResult.getIdNum() + "\r\n");
        }
        return resultBuilder.toString();
    }

    private void displayFailure(String str) {
        this.mTextView.setText("Failure. " + str);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        if (this.localAnalyzer != null) {
            try {
                this.localAnalyzer.stop();
            } catch (IOException e) {
                Log.d(TAG, "Stop failed:" + e.getMessage());
            }
        }

    }

    /**
     * Use the Chinese second-generation ID card pre-processing plug-in to identify video stream ID cards.
     * Create a recognition result callback function to process the identification result of the ID card.
     */
    private MLVnIcrCapture.CallBack idCallBack = new MLVnIcrCapture.CallBack() {
        // Identify successful processing.
        @Override
        public void onSuccess(MLVnIcrCaptureResult idCardResult) {
            Log.i(TAG, "IdCallBack onRecSuccess");
            if (idCardResult == null) {
                Log.i(TAG, "IdCallBack onRecSuccess idCardResult is null");
                return;
            }
            Bitmap bitmap = idCardResult.getCardBitmap();
            if (isFront) {
                cardFront = bitmap;
                previewImageFront.setImageBitmap(bitmap);
                cardResultFront = formatIdCardResult(idCardResult, true);
            }
            if (!(cardResultFront.equals("") && cardResultBack.equals(""))) {
                mTextView.setText(cardResultFront);
                mTextView.append(cardResultBack);
            }
        }

        // User cancellation processing.
        @Override
        public void onCanceled() {
            displayFailure("IdCallBackonRecCanceled");
            Log.i(TAG, "IdCallBackonRecCanceled");
        }

        // Identify failure processing.
        @Override
        public void onFailure(int retCode, Bitmap bitmap) {
            displayFailure("IdCallBackonRecFailed. " + "retcode is :" + retCode);
            Log.i(TAG, "IdCallBackonRecFailed");
        }

        // Camera unavailable processing, the reason that the camera is unavailable is generally that the user has not been granted camera permissions.
        @Override
        public void onDenied() {
            displayFailure("IdCallBackonCameraDenied");
            Log.i(TAG, "IdCallBackonCameraDenied");
        }
    };

    /**
     * Set the recognition parameters, call the recognizer capture interface for recognition, and the recognition result will be returned through the callback function.
     *
     * @param callback The callback of ID cards analyse.
     */
    private void startCaptureActivity(MLVnIcrCapture.CallBack callback) {
        MLVnIcrCaptureConfig config = new MLVnIcrCaptureConfig.Factory().create();
        MLVnIcrCapture icrCapture = MLVnIcrCaptureFactory.getInstance().getIcrCapture(config);
        icrCapture.capture(callback, this);
    }

    /**
     * Set the recognition parameters, call the recognizer captureImage interface for recognition, and the recognition result will be returned through the callback function.
     *
     * @param callback The callback of ID cards analyse.
     */

    private void startCaptureImageActivity(MLVnIcrCapture.CallBack callback) {

        imageBitmap = BitmapUtils.loadFromPath(IcrVnAnalyseActivity.this, mImageUri, getWidth(), getHeight());
        if (imageBitmap == null) {
            Log.d(TAG, "imageBitmap is null");
            return;
        }

        cardFront = imageBitmap;
        previewImageFront.setImageBitmap(cardFront);
        localAnalyzer();

        MLVnIcrCaptureConfig config = new MLVnIcrCaptureConfig.Factory().create();
        MLVnIcrCapture icrCapture = MLVnIcrCaptureFactory.getInstance().getIcrCapture(config);
        icrCapture.captureImage(this.cardFront, callback);
    }

    private int getWidth() {
        Display display = getWindowManager().getDefaultDisplay();
        int width;
        if (this.getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE) {
            width = display.getHeight();
        } else {
            width = display.getWidth();
        }
        return width;
    }

    private int getHeight() {
        Display display = getWindowManager().getDefaultDisplay();
        int height;
        if (this.getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE) {
            height = display.getWidth();
        } else {
            height = display.getHeight();
        }
        return height;
    }
}