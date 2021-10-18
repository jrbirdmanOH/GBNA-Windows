// License.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include <stdlib.h>
#ifdef WIN32
#include <tchar.h>
#else
#include <string.h>
#endif

#define VALIDATION_SUCCESS 1
#define VALIDATION_FAILED -1
const int LICENSE_LENGTH = 16;
const int PRODUCT_NUMBER_LENGTH = 3;
const int SERIAL_NUMBER_LENGTH = 6;
const int PRODUCT_CODE_LENGTH = 7;

#ifdef WIN32
BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
    return TRUE;
}
#endif

#ifndef WIN32
/**
 * Ansi C "itoa" based on Kernighan & Ritchie's "Ansi C":
 */
void strreverse(char* begin, char* end)
{
	char aux;
	while(end>begin)
		aux=*end, *end--=*begin, *begin++=aux;
}

void _itoa_s(int value, char* str, int base)
{
	static char num[] = "0123456789abcdefghijklmnopqrstuvwxyz";
	char* wstr=str;
	int sign;

	// Validate base
	if (base<2 || base>35){ *wstr='\0'; return; }

	// Take care of sign
	if ((sign=value) < 0) value = -value;

	// Conversion. Number is reversed.
	do *wstr++ = num[value%base]; while(value/=base);
	if(sign<0) *wstr++='-';
	*wstr='\0';

	// Reverse string
	strreverse(str,wstr-1);
}
#endif

const char* GetProductCode(int nProductCode)
{
	char* pszCode;
	switch(nProductCode)
	{
	case 1:
		pszCode = "GBNA";
		break;
	case 2:
		pszCode = "FGBB";
		break;
	case 3:
		pszCode = "AL";
		break;
	case 4:
		pszCode = "AK";
		break;
	case 5:
		pszCode = "AZ";
		break;
    case 6:
		pszCode = "AR";
		break;
    case 7:
		pszCode = "CA";
		break;
    case 8:
		pszCode = "CO";
		break;
    case 9:
		pszCode = "CT";
		break;
    case 10:
		pszCode = "DE";
		break;
    case 11:
		pszCode = "DC";
		break;
    case 12:
		pszCode = "FL";
		break;
    case 13:
		pszCode = "GA";
		break;
    case 14:
		pszCode = "ID";
		break;
    case 15:
		pszCode = "IL";
		break;
    case 16:
		pszCode = "IN";
		break;
    case 17:
		pszCode = "IA";
		break;
    case 18:
		pszCode = "KS";
		break;
    case 19:
		pszCode = "KY";
		break;
    case 20:
		pszCode = "LA";
		break;
    case 21:
		pszCode = "ME";
		break;
    case 22:
		pszCode = "MD";
		break;
    case 23:
		pszCode = "MA";
		break;
    case 24:
		pszCode = "MI";
		break;
    case 25:
		pszCode = "MN";
		break;
    case 26:
		pszCode = "MS";
		break;
    case 27:
		pszCode = "MO";
		break;
    case 28:
		pszCode = "MT";
		break;
    case 29:
		pszCode = "NE";
		break;
    case 30:
		pszCode = "NV";
		break;
    case 31:
		pszCode = "NH";
		break;
    case 32:
		pszCode = "NJ";
		break;
    case 33:
		pszCode = "NM";
		break;
    case 34:
		pszCode = "NY";
		break;
    case 35:
		pszCode = "NC";
		break;
    case 36:
		pszCode = "ND";
		break;
    case 37:
		pszCode = "OH";
		break;
    case 38:
		pszCode = "OK";
		break;
    case 39:
		pszCode = "OR";
		break;
    case 40:
		pszCode = "PA";
		break;
    case 41:
		pszCode = "RI";
		break;
    case 42:
		pszCode = "SC";
		break;
    case 43:
		pszCode = "SD";
		break;
    case 44:
		pszCode = "TN";
		break;
    case 45:
		pszCode = "TX";
		break;
    case 46:
		pszCode = "UT";
		break;
    case 47:
		pszCode = "VT";
		break;
    case 48:
		pszCode = "VA";
		break;
    case 49:
		pszCode = "WA";
		break;
    case 50:
		pszCode = "WV";
		break;
    case 51:
		pszCode = "WI";
		break;
    case 52:
		pszCode = "WY";
		break;
    case 53:
		pszCode = "AB";
		break;
    case 54:
		pszCode = "BC";
		break;
    case 55:
		pszCode = "MB";
		break;
    case 56:
		pszCode = "NB";
		break;
    case 57:
		pszCode = "NF";
		break;
    case 58:
		pszCode = "NT";
		break;
    case 59:
		pszCode = "NS";
		break;
    case 60:
		pszCode = "NU";
		break;
    case 61:
		pszCode = "ON";
		break;
    case 62:
		pszCode = "PE";
		break;
    case 63:
		pszCode = "QC";
		break;
    case 64:
		pszCode = "SK";
		break;
    case 65:
		pszCode = "YT";
		break;
    case 66:
		pszCode = "DUCK";
		break;
    case 67:
		pszCode = "HAWK";
		break;
    case 68:
		pszCode = "WARBLER";
		break;
    case 69:
		pszCode = "CAMA";
		break;
    case 70:
		pszCode = "CAPR";
		break;
    case 71:
		pszCode = "USNE";
		break;
    case 72:
		pszCode = "USAC";
		break;
    case 73:
		pszCode = "USMW";
		break;
    case 74:
		pszCode = "USSO";
		break;
    case 75:
		pszCode = "USGP";
		break;
    case 76:
		pszCode = "USSW";
		break;
    case 77:
		pszCode = "USRK";
		break;
    case 78:
		pszCode = "USNW";
		break;
    case 79:
		pszCode = "BDNAE";
		break;
    case 80:
		pszCode = "BDWE";
		break;
    case 81:
		pszCode = "CAN";
		break;
    case 82:
		pszCode = "SAMPLER";
		break;
	case 999:
		pszCode = "BOMR";
		break;
	default:
		pszCode = "";
		break;
	}

	return pszCode;
}

int SumDigits(const char* szNumber)
{
	const int BUFFER_SIZE = 3;

	int sum = 0;
	char ch[BUFFER_SIZE];

	size_t iLength = strlen(szNumber);
	for(size_t i=0; i < iLength; i++)
	{
		memset(ch, '\0', BUFFER_SIZE);
		ch[0] = szNumber[i];
		sum += atoi(ch);
	}

	return sum;
}

extern "C" int Validate(const char* szProductKey, char* szProduct, int nProductMaxCount, char* szSerialNumber, int nSerialMaxCount)
{
	const int BUFFER_SIZE = 3;

	char ch[BUFFER_SIZE];
	char szLicenseKey[MAX_PATH];

	memset(szLicenseKey, '\0', MAX_PATH);

	size_t serialSize = ::strlen(szProductKey);
	if(serialSize > MAX_PATH)
	{
		return 0;
	}

	int index = 0;
	for(size_t i=0; i < serialSize; i++)
	{
		if(szProductKey[i] != '-')
		{
			szLicenseKey[index] = szProductKey[i];
			index++;
		}
	}

	size_t licenseLength = strlen(szLicenseKey);
	if(licenseLength != LICENSE_LENGTH)
	{
		return 0;
	}

	int sumOdd = 0;
	for(size_t i=0; i < licenseLength; i+=2)
	{
		memset(ch, '\0', BUFFER_SIZE);
		ch[0] = szLicenseKey[i];
		int value = atoi(ch) * 2;
		_itoa_s(value, ch, 10);
		sumOdd += SumDigits(ch);
	}

	// Calculate sum based on EVEN digits
	int sumEven = 0;
	for (size_t i=1; i < licenseLength; i+=2)
	{
		memset(ch, '\0', BUFFER_SIZE);
		ch[0] = szLicenseKey[i];
		sumEven += atoi(ch);
	}

	int sum = sumOdd + sumEven;

	if (sum % 10 != 0)
	{
		return 0;
	}

	memset(ch, '\0', BUFFER_SIZE);
	ch[0] = szLicenseKey[0];
	int patternCode = atoi(ch);

	int productCodePositions[PRODUCT_NUMBER_LENGTH];
	int serialNumberPositions[SERIAL_NUMBER_LENGTH];
	int randomPositions[LICENSE_LENGTH - PRODUCT_NUMBER_LENGTH - SERIAL_NUMBER_LENGTH];
	switch (patternCode)
	{
		case 0:
			productCodePositions[0] = 9;
			productCodePositions[1] = 11;
			productCodePositions[2] = 14;
			serialNumberPositions[0] = 2;
			serialNumberPositions[1] = 6;
			serialNumberPositions[2] = 10;
			serialNumberPositions[3] = 12;
			serialNumberPositions[4] = 13;
			serialNumberPositions[5] = 15;
			randomPositions[0] = 3;
			randomPositions[1] = 4;
			randomPositions[2] = 5;
			randomPositions[3] = 7;
			randomPositions[4] = 8;
			break;
		case 1:
			productCodePositions[0] = 2;
			productCodePositions[1] = 14;
			productCodePositions[2] = 15;
			serialNumberPositions[0] = 6;
			serialNumberPositions[1] = 7;
			serialNumberPositions[2] = 9;
			serialNumberPositions[3] = 10;
			serialNumberPositions[4] = 11;
			serialNumberPositions[5] = 12;
			randomPositions[0] = 3;
			randomPositions[1] = 4;
			randomPositions[2] = 5;
			randomPositions[3] = 8;
			randomPositions[4] = 13;
			break;
		case 2:
			productCodePositions[0] = 5;
			productCodePositions[1] = 13;
			productCodePositions[2] = 15;
			serialNumberPositions[0] = 2;
			serialNumberPositions[1] = 3;
			serialNumberPositions[2] = 6;
			serialNumberPositions[3] = 9;
			serialNumberPositions[4] = 11;
			serialNumberPositions[5] = 14;
			randomPositions[0] = 4;
			randomPositions[1] = 7;
			randomPositions[2] = 8;
			randomPositions[3] = 10;
			randomPositions[4] = 12;
			break;
		case 3:
			productCodePositions[0] = 6;
			productCodePositions[1] = 7;
			productCodePositions[2] = 13;
			serialNumberPositions[0] = 3;
			serialNumberPositions[1] = 4;
			serialNumberPositions[2] = 8;
			serialNumberPositions[3] = 11;
			serialNumberPositions[4] = 14;
			serialNumberPositions[5] = 15;
			randomPositions[0] = 2;
			randomPositions[1] = 5;
			randomPositions[2] = 9;
			randomPositions[3] = 10;
			randomPositions[4] = 12;
			break;
		case 4:
			productCodePositions[0] = 5;
			productCodePositions[1] = 12;
			productCodePositions[2] = 15;
			serialNumberPositions[0] = 3;
			serialNumberPositions[1] = 6;
			serialNumberPositions[2] = 7;
			serialNumberPositions[3] = 9;
			serialNumberPositions[4] = 10;
			serialNumberPositions[5] = 14;
			randomPositions[0] = 2;
			randomPositions[1] = 4;
			randomPositions[2] = 8;
			randomPositions[3] = 11;
			randomPositions[4] = 13;
			break;
		case 5:
			productCodePositions[0] = 2;
			productCodePositions[1] = 9;
			productCodePositions[2] = 13;
			serialNumberPositions[0] = 4;
			serialNumberPositions[1] = 5;
			serialNumberPositions[2] = 6;
			serialNumberPositions[3] = 11;
			serialNumberPositions[4] = 14;
			serialNumberPositions[5] = 15;
			randomPositions[0] = 3;
			randomPositions[1] = 6;
			randomPositions[2] = 8;
			randomPositions[3] = 10;
			randomPositions[4] = 12;
			break;
		case 6:
			productCodePositions[0] = 5;
			productCodePositions[1] = 8;
			productCodePositions[2] = 14;
			serialNumberPositions[0] = 4;
			serialNumberPositions[1] = 7;
			serialNumberPositions[2] = 9;
			serialNumberPositions[3] = 11;
			serialNumberPositions[4] = 12;
			serialNumberPositions[5] = 15;
			randomPositions[0] = 2;
			randomPositions[1] = 3;
			randomPositions[2] = 6;
			randomPositions[3] = 10;
			randomPositions[4] = 13;
			break;
		case 7:
			productCodePositions[0] = 8;
			productCodePositions[1] = 12;
			productCodePositions[2] = 15;
			serialNumberPositions[0] = 3;
			serialNumberPositions[1] = 4;
			serialNumberPositions[2] = 6;
			serialNumberPositions[3] = 10;
			serialNumberPositions[4] = 11;
			serialNumberPositions[5] = 13;
			randomPositions[0] = 2;
			randomPositions[1] = 5;
			randomPositions[2] = 7;
			randomPositions[3] = 9;
			randomPositions[4] = 14;
			break;
		case 8:
			productCodePositions[0] = 9;
			productCodePositions[1] = 13;
			productCodePositions[2] = 14;
			serialNumberPositions[0] = 3;
			serialNumberPositions[1] = 4;
			serialNumberPositions[2] = 7;
			serialNumberPositions[3] = 8;
			serialNumberPositions[4] = 12;
			serialNumberPositions[5] = 15;
			randomPositions[0] = 2;
			randomPositions[1] = 5;
			randomPositions[2] = 6;
			randomPositions[3] = 10;
			randomPositions[4] = 11;
			break;
		case 9:
			productCodePositions[0] = 4;
			productCodePositions[1] = 8;
			productCodePositions[2] = 15;
			serialNumberPositions[0] = 5;
			serialNumberPositions[1] = 6;
			serialNumberPositions[2] = 10;
			serialNumberPositions[3] = 11;
			serialNumberPositions[4] = 12;
			serialNumberPositions[5] = 14;
			randomPositions[0] = 2;
			randomPositions[1] = 3;
			randomPositions[2] = 7;
			randomPositions[3] = 9;
			randomPositions[4] = 13;
			break;
	}

	char szProductCode[PRODUCT_NUMBER_LENGTH + 1];
	for (int i=0; i < PRODUCT_NUMBER_LENGTH; i++)
	{
		szProductCode[i] = szLicenseKey[productCodePositions[i] - 1];
	}
	szProductCode[PRODUCT_NUMBER_LENGTH] = '\0';
	int nProductCode = atoi(szProductCode);
#ifdef WIN32
	strcpy_s(szProduct, nProductMaxCount, GetProductCode(nProductCode));
#else
	strcpy(szProduct, GetProductCode(nProductCode));
#endif

	// Check if this is a valid product
	if(strlen(szProduct) == 0)
	{
		return 0;
	}

	for (int i=0; i < SERIAL_NUMBER_LENGTH; i++)
	{
		szSerialNumber[i] = szLicenseKey[serialNumberPositions[i]];
	}
	szSerialNumber[SERIAL_NUMBER_LENGTH] = '\0';

	return 1;
}

#ifdef WIN32
LONG __stdcall ValidateSN(HWND hwnd, LPSTR szSrcDir, LPSTR szSupport, LPSTR szSerialNum, LPSTR szDbase)
{
	char szProductCode[PRODUCT_CODE_LENGTH + 1];
	char szSerialNumber[SERIAL_NUMBER_LENGTH + 1];

	BOOL valid = Validate(szSerialNum, szProductCode, sizeof(szProductCode), szSerialNumber, sizeof(szSerialNumber));

	if(valid)
	{
		return VALIDATION_SUCCESS;
	}
	else
	{
		MessageBox(hwnd, TEXT("Invalid license key."), TEXT("Thayer eField Guide Viewer"), MB_OK | MB_ICONEXCLAMATION | MB_APPLMODAL);

		return VALIDATION_FAILED;
	}
}
#endif
