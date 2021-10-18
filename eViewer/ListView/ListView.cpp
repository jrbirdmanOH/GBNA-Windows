// ListView.cpp : Defines the entry point for the DLL application.
//

#define _WIN32_IE 0x501
#define WINVER 0x0501

#include "stdafx.h"
#include <windows.h>
#include <commctrl.h>
#include <tchar.h>
#include <shlwapi.h>
#include "resource.h"
#include "ListView.h"

#ifndef HDF_SORTUP
#define HDF_SORTUP                  0x0400
#endif
#ifndef HDF_SORTDOWN
#define HDF_SORTDOWN                0x0200
#endif

#ifdef _MANAGED
#pragma managed(push, off)
#endif

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    return TRUE;
}

#ifdef _MANAGED
#pragma managed(pop)
#endif

BOOL IsCommCtrlVersion6()
{
    static BOOL isCommCtrlVersion6 = -1;
    if (isCommCtrlVersion6 != -1)
	{
        return isCommCtrlVersion6;
	}
    
    // The default value
    isCommCtrlVersion6 = FALSE;
    
    HINSTANCE commCtrlDll = LoadLibrary(_T("comctl32.dll"));
    if(commCtrlDll)
    {
        DLLGETVERSIONPROC pDllGetVersion;
        pDllGetVersion = (DLLGETVERSIONPROC)GetProcAddress(commCtrlDll, "DllGetVersion");
        
        if (pDllGetVersion)
        {
            DLLVERSIONINFO dvi = {0};
            dvi.cbSize = sizeof(DLLVERSIONINFO);
            (*pDllGetVersion)(&dvi);
            
            isCommCtrlVersion6 = (dvi.dwMajorVersion == 6);
        }
        
        FreeLibrary(commCtrlDll);
    }
    
    return isCommCtrlVersion6;
}

extern "C" LISTVIEW_API void ListView_SetHeaderSortImage(HWND listView, int columnIndex, BOOL isAscending)
{
    HWND header = ListView_GetHeader(listView);
    BOOL isCommonControlVersion6 = IsCommCtrlVersion6();
    
    int columnCount = Header_GetItemCount(header);
    for (int i = 0; i < columnCount; i++)
    {
        HDITEM hi = {0};
        
        // Only need to retrieve the format if on Windows XP or greater.
		// If not, then need to retrieve the bitmap also.
        hi.mask = HDI_FORMAT | (isCommonControlVersion6 ? 0 : HDI_BITMAP);
        
        Header_GetItem(header, i, &hi);
        
        // Set sort image to this column
        if (i == columnIndex)
        {
            // Windows XP has an easier way to show the sort order in
            // the header: just have to set a flag and windows will
            // do the drawing.  Prior to Windows XP, no easy way.
            if (isCommonControlVersion6)
            {
                hi.fmt &= ~(HDF_SORTDOWN | HDF_SORTUP);
                hi.fmt |= isAscending ? HDF_SORTUP : HDF_SORTDOWN;
            }
            else
            {
                UINT bitmapID = isAscending ? IDB_UPARROW : IDB_DOWNARROW;
                
                // If there's a bitmap, let's delete it.
                if (hi.hbm)
				{
                    DeleteObject(hi.hbm);
				}
                
                hi.fmt |= HDF_BITMAP | HDF_BITMAP_ON_RIGHT;
//              hi.hbm = (HBITMAP)LoadImage(GetModuleHandle(NULL), MAKEINTRESOURCE(bitmapID), IMAGE_BITMAP, 0,0, LR_LOADMAP3DCOLORS);
                hi.hbm = (HBITMAP)LoadImage(GetModuleHandle(_T("ListView")), MAKEINTRESOURCE(bitmapID), IMAGE_BITMAP, 0, 0, LR_LOADMAP3DCOLORS);
            }
        }
        // Remove sort image (if exists) from other columns
        else
        {
            if (isCommonControlVersion6)
			{
                hi.fmt &= ~(HDF_SORTDOWN | HDF_SORTUP | HDF_IMAGE);
			}
            else
            {
                // If there's a bitmap, let's delete it.
                if (hi.hbm)
				{
                    DeleteObject(hi.hbm);
				}
                
                // Remove flags that tell windows to look for a bitmap
                hi.mask &= ~(HDI_BITMAP | HDI_IMAGE);
                hi.fmt &= ~(HDF_BITMAP | HDF_BITMAP_ON_RIGHT | HDF_IMAGE);
            }
        }
        
        Header_SetItem(header, i, &hi);
    }
}

extern "C" LISTVIEW_API void ListView_ClearAllHeaderImageFlags(HWND listView)
{
    HWND header = ListView_GetHeader(listView);
    BOOL isCommonControlVersion6 = IsCommCtrlVersion6();
    
    int columnCount = Header_GetItemCount(header);
    for (int i = 0; i < columnCount; i++)
    {
        HDITEM hi = {0};
        
        // Only need to retrieve the format if on Windows XP or greater.
		// If not, then need to retrieve the bitmap also.
        hi.mask = HDI_FORMAT | (isCommonControlVersion6 ? 0 : HDI_BITMAP);
        
        Header_GetItem(header, i, &hi);
        
        // Remove sort image (if exists)
        if (isCommonControlVersion6)
		{
            hi.fmt &= ~(HDF_SORTDOWN | HDF_SORTUP | HDF_IMAGE);
		}
        else
        {
            // If there's a bitmap, let's delete it.
            if (hi.hbm)
			{
                DeleteObject(hi.hbm);
			}
            
            // Remove flags that tell windows to look for a bitmap
            hi.mask &= ~(HDI_BITMAP | HDI_IMAGE);
            hi.fmt &= ~(HDF_BITMAP | HDF_BITMAP_ON_RIGHT | HDF_IMAGE);
        }
        
        Header_SetItem(header, i, &hi);
    }
}

extern "C" LISTVIEW_API void ListView_SetHeaderImageFlag(HWND listView, int columnIndex)
{
    HWND header = ListView_GetHeader(listView);
    BOOL isCommonControlVersion6 = IsCommCtrlVersion6();
    
    HDITEM hi = {0};
    
    // Only need to retrieve the format if on Windows XP or greater.
	// If not, then need to retrieve the bitmap also.
    hi.mask = HDI_FORMAT | (isCommonControlVersion6 ? 0 : HDI_BITMAP);
    
    Header_GetItem(header, columnIndex, &hi);
    
    if (isCommonControlVersion6)
	{
        hi.fmt |= HDF_BITMAP_ON_RIGHT | HDF_IMAGE;
	}
    else
    {
        hi.mask |= HDI_IMAGE;
        hi.fmt |= HDF_BITMAP_ON_RIGHT | HDF_IMAGE;
    }
    
    Header_SetItem(header, columnIndex, &hi);
}
